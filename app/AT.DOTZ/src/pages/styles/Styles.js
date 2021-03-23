import styled from 'styled-components/native';

export const Input = styled.TextInput.attrs({
  //selectionColor : 'green'
})`
  margin-left: 15px;
  margin-right: 15px;
  height: 40px;
  padding: 10px;
  border-radius: 3px;
  border-width: 1px;
  border-color: #969696;
  font-size: 16px;
`;

export const InputView = styled.View`
  margin-left: 15px;
  margin-right: 15px;
  height: 40px;
  padding: 10px;
  border-radius: 3px;
  border-width: 1px;
  border-color: #969696;
  font-Size: 16px;
`;

export const Label = styled.Text`
  margin-top: 10px;
  margin-left: 15px;
  margin-right: 15px;
  margin-bottom: 4px;
  color: #1f2a30;
  font-size: 14px;
`;

export const ViewCardText = styled.View`
  flex: 1; 
  flex-direction: row; 
  margin-right: 4px;  
  background-color: #f3f3f3; 
  border-color:#f29433;
  border-width: 1px;
  border-radius: 8px;
`;

export const ViewCardRow = styled.View`
  flex-direction: row; 
  margin-left: 8px;
  margin-right: 8px;
  margin-bottom: 4px;
  height: 80px;
`;


export const LabelAccount = styled.Text`
  margin-top: 10px;
  margin-left: 15px;
  margin-right: 15px;
  margin-bottom: 4px;
  color: #1f2a30;
  font-size: 15px;
  font-weight: bold;
`;


export const ButtonTouchableHighlightAccount = styled.TouchableHighlight`
  margin-top: 10px;
  height: 60px;
  margin-left: 4px;
  margin-right: 4px; 
`;

export const ButtonTextAccount = styled.Text`
  color: #FFF;
  background-color: #f29433;
  height: 64px;
  font-size: 16px;
  border-radius: 8px;
  text-align: center;
  textAlignVertical: center;
`;

export const ButtonViewAccount = styled.View`
  flex: 1;
  justify-content: center;
`;

export const ButtonViewCardAccount = styled.View`
  flex: 0.5;
`;

export const ButtonTouchableHighlight = styled.TouchableHighlight`
  margin-top: 10px;
  height: 40px;
  margin-left: 15px;
  margin-right: 15px; 
`;

export const ButtonText = styled.Text`
  color: #FFF;
  background-color: #f29433;
  height: 44px;
  font-size: 16px;
  border-radius: 3px;
  text-align: center;
  textAlignVertical: center;
`;

export const ButtonView = styled.View`
  flex: 1;
  justify-content: center;
`;

export const ButtonTouchableHighlightCard = styled.TouchableHighlight`
  height: 22px;
  margin-left: 2px;
  margin-right: 2px; 
  flex: 1;
`;


export const ButtonTextCard = styled.Text.attrs(props => ({
}))`
  color: #FFF;
  background-color: ${props => props.inputColor || "#000"};
  height: 26px;
  font-size: 14px;
  border-radius: 3px;
  text-align: center;
  textAlignVertical: center;
`;


export const ButtonViewCard = styled.View`
  flex: 1;
  justify-content: center;
`;

export const ContentView = styled.View`
   background-color: #FFF;
   flex: 1;
`;

export const FormContentView = styled.View`
   flex: 1;
`;

export const RowView = styled.View`
   flex: 1;
`;

export const LogoView = styled.View`
  flex: 0.1;
  justify-content: center;
  align-items: center;
`;

export const LogoImage = styled.Image`

`;

export const ActivityIndicatorLoadView = styled.View`
  flex: 1;
  justify-content: center;
  align-items: center;
`;

export const ActivityIndicatorLoad = styled.ActivityIndicator`
  flex: 1;
  justify-content: center;
  align-items: center;
`;
export const Loading = styled.ActivityIndicator.attrs({
  size: 'large',
  color: '#999',
})`
  margin: 30px 0;
`;

export const ViewRow = styled.View.attrs(props => ({
}))`
 
`;