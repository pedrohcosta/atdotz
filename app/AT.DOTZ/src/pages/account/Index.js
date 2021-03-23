import React, { useState, useEffect, useRef } from 'react';
import { View, BackHandler, Text} from 'react-native';
import {
    Label, ContentView,
    ActivityIndicatorLoadView, ActivityIndicatorLoad,
    FormContentView,  ButtonTouchableHighlightAccount, ButtonTextAccount, ButtonViewAccount,
    ButtonViewCardAccount,LabelAccount,ViewCardText,ViewCardRow
} from '../styles/Styles';

import { useFocusEffect } from '@react-navigation/native';

import Util from '../../util/Util';
import AccountController from '../../services/AccountController';

function Index(props) {

    const [account, setAccount] = useState({});

    const [preLoad, setPreLoad] = useState(false);

    const refButtonPayment = useRef(null);
    const refButtonExtract = useRef(null);
    const refButtonCard = useRef(null);

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
    
    useEffect(() => {
        
    }, []);

    async function load() {
        
        setPreLoad(true);
        const mail = props.route.params.mail;
        const objResult = await AccountController.getAccountMail(mail);
        setPreLoad(false);

        if (objResult != null) {
            setAccount(objResult)
        } else {
            Util.erro('Erro ao buscar conta!');
        }
    }

    async function payment() {
        props.navigation.navigate('AccountPayment', {account: account});
    }

    async function card() {
        props.navigation.navigate('AccountCard', {account: account});
    }

    async function extract() {
        props.navigation.navigate('AccountExtract', {account: account});
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
                    <View style={{}}>

                        <ViewCardRow>
                            <ViewCardText>
                                <View>
                                    <LabelAccount>Olá {account.name} seu numero de conta é: {account.number}</LabelAccount>
                                </View>
                            </ViewCardText>
                        </ViewCardRow>

                        <ViewCardRow>
                           
                            <ViewCardText>
                                <View>
                                    <LabelAccount>Saldo</LabelAccount>
                                    <LabelAccount>{account.balance}</LabelAccount>
                                </View>
                            </ViewCardText>
                            
                            <ViewCardText>
                                <View>
                                    <LabelAccount>Dotz</LabelAccount>
                                    <LabelAccount>{account.dotz}</LabelAccount>
                                </View>
                            </ViewCardText>

                        </ViewCardRow>
                    </View>
                    
                    <View style={{top:40,flex:1}}>
                        <ViewCardRow>
                            <ButtonViewCardAccount>
                                <View>
                                    <ButtonTouchableHighlightAccount ref={refButtonExtract} onPress={() => { extract() }}>
                                        <ButtonViewAccount>
                                            <ButtonTextAccount>Extrato</ButtonTextAccount>
                                        </ButtonViewAccount>
                                    </ButtonTouchableHighlightAccount>
                                </View>
                            </ButtonViewCardAccount>
                            
                            <ButtonViewCardAccount>
                                <View>
                                    <ButtonTouchableHighlightAccount ref={refButtonCard} onPress={() => { card() }}>
                                        <ButtonViewAccount>
                                            <ButtonTextAccount>Cartão</ButtonTextAccount>
                                        </ButtonViewAccount>
                                    </ButtonTouchableHighlightAccount>
                                </View>
                            </ButtonViewCardAccount>
               
                        </ViewCardRow>
                        <ViewCardRow>
                            
                            <ButtonViewCardAccount>
                                <View>
                                    <ButtonTouchableHighlightAccount ref={refButtonPayment} onPress={() => { payment() }}>
                                        <ButtonViewAccount>
                                            <ButtonTextAccount>Pagar Boleto</ButtonTextAccount>
                                        </ButtonViewAccount>
                                    </ButtonTouchableHighlightAccount>
                                </View>
                            </ButtonViewCardAccount>
               
                        </ViewCardRow>
                    </View>

                    
                </FormContentView>
            }
        </ContentView>

    );
}
export default Index;