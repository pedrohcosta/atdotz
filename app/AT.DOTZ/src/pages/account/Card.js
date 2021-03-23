import React, { useState, useEffect, useRef } from 'react';
import {
    View, Button, FlatList, BackHandler,
    TouchableOpacity, Text
} from 'react-native';

import {
    ContentView,
    ActivityIndicatorLoadView, ActivityIndicatorLoad,
    FormContentView
} from '../styles/Styles';

import { useFocusEffect } from '@react-navigation/native';

import Util from '../../util/Util';
import AccountController from '../../services/AccountController';

function Card(props) {

    const [listCard, setListCard] = useState([]);
    const [preLoad, setPreLoad] = useState(false);
    const [selectedId, setSelectedId] = useState(null);

    const refList = useRef(null);

    useEffect(() => {
        BackHandler.addEventListener('hardwareBackPress', () => {
            return true;
        });
    }, []);

    useFocusEffect(
        React.useCallback(() => {
            load();
        }, [])
    );
    
    React.useLayoutEffect(() => {
        props.navigation.setOptions({
            headerRight: () => (
                <View style={{ padding: 6 }}>
                    <View style={{ flexDirection: "row" }}>
                        <View style={{ flex: 0.5, flexDirection: "row", padding: 3 }}>
                            <Button
                                onPress={() => {
                                    props.navigation.navigate('AccountIndex', {mail:props.route.params.account.mail});
                                }}
                                title="Voltar"
                                color="#f29433"
                            />
                        </View>
                    </View>
                </View>
            ),
        });
    }, [props.navigation]);


    async function load() {
        
        setPreLoad(true);
        const id = props.route.params.account.id;
        const objResult = await AccountController.getCard(id);
        setPreLoad(false);
        if (objResult != null) {
            setListCard(objResult)
        } else {
            Util.erro('Erro ao buscar card!');
        }
    }
    
    return (
        <ContentView>
            {preLoad ?
                <ActivityIndicatorLoadView>
                    <ActivityIndicatorLoad
                        color='#999'
                        size="large"
                    />
                </ActivityIndicatorLoadView> :

                <FormContentView>

                    <View style={{ flex: 1, height: 100 }}>
                        <FlatList
                            persistentScrollbar={true}
                            keyboardShouldPersistTaps='always'
                            key="list"
                            data={listCard}
                            keyExtractor={item => String(item.id)}
                            extraData={selectedId}
                            ref={refList}
                            //onRefresh={refreshList}
                            //refreshing={refreshing}
                            //ListFooterComponent={loading && <Loading />}
                            renderItem={({ item, index }) => {
                                return (
                                    <TouchableOpacity
                                        onPress={() => {
                                            setSelectedId(item.id);
                                        }}
                                        style={[{
                                            padding: 12,
                                            marginVertical: 6,
                                            marginHorizontal: 12,
                                            backgroundColor: '#f3f3f3',
                                            borderRadius: 8,
                                            borderColor: '#f29433',
                                            borderWidth: 1
                                        }]}
                                    >
                                        <View>
                                            <View style={{ flexDirection: "row" }}>
                                                <View style={{ flexDirection: "row", marginRight: 4 }}>
                                                    <View>
                                                        <Text style={{ fontSize: 15, fontWeight: 'bold' }}>Numero:</Text>
                                                    </View>
                                                    <View style={{ paddingLeft: 4, flexDirection: "row" }}>
                                                        <Text>{item.number}</Text>
                                                    </View>
                                                </View>
                                            </View>
                                            <View style={{ flexDirection: "row" }}>
                                                <View style={{ flex: 0.5, flexDirection: "row", marginRight: 4 }}>
                                                    <View>
                                                        <Text style={{ fontSize: 15, fontWeight: 'bold' }}>Ativo:</Text>
                                                    </View>
                                                    <View style={{ paddingLeft: 4, flexDirection: "row" }}>
                                                        <Text>{item.active?'Habilitado':'Desabiltado'}</Text>
                                                    </View>
                                                </View>
                                                <View style={{ flex: 0.5, flexDirection: "row" }}>
                                                    <View>
                                                        <Text style={{ fontSize: 15, fontWeight: 'bold' }}>Data:</Text>
                                                    </View>
                                                    <View style={{ paddingLeft: 4, flexDirection: "row" }}>
                                                        <Text>{item.data.substring(0,10)}</Text>
                                                    </View>
                                                </View>
                                            </View>
                                            <View style={{ flexDirection: "row" }}>
                                                <View style={{ flex: 0.5, flexDirection: "row", marginRight: 4 }}>
                                                    <View>
                                                        <Text style={{ fontSize: 15, fontWeight: 'bold' }}>Tipo:</Text>
                                                    </View>
                                                    <View style={{ paddingLeft: 4, flexDirection: "row" }}>
                                                        <Text>{item.type==1?'Fisico':'Virtual'}</Text>
                                                    </View>
                                                </View>
                                            </View>
                                            
                                        </View>
                                    </TouchableOpacity>
                                )
                            }}
                        />
                    </View>

                </FormContentView>
            }
        </ContentView>

    );
}

export default Card;