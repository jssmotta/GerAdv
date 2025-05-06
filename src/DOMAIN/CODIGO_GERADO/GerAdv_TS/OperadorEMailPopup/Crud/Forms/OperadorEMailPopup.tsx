// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperadorEMailPopup } from '@/app/GerAdv_TS/OperadorEMailPopup/Interfaces/interface.OperadorEMailPopup';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface OperadorEMailPopupFormProps {
    operadoremailpopupData: IOperadorEMailPopup;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorEMailPopupForm: React.FC<OperadorEMailPopupFormProps> = ({
    operadoremailpopupData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadoremailpopupData.id === 0) {
    operadoremailpopupData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        operadoremailpopupData.operador = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('OperadorEMailPopupForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`OperadorEMailPopupForm-${operadoremailpopupData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadoremailpopupData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorEMailPopupForm-${operadoremailpopupData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={operadoremailpopupData.nome}
            placeholder={`Digite nome operador e mail popup`}
            onChange={onChange}
            required
          />

            <OperadorComboBox
            name={'operador'}
            value={operadoremailpopupData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<Input
autoComplete="off"
type="password"
id="senha"
label="Senha"
className="inputIncNome"
name="senha"
value={operadoremailpopupData.senha}
onChange={onChange}               
/>

<Input
type="text"
id="smtp"
label="SMTP"
className="inputIncNome"
name="smtp"
value={operadoremailpopupData.smtp}
onChange={onChange}               
/>

<Input
type="text"
id="pop3"
label="POP3"
className="inputIncNome"
name="pop3"
value={operadoremailpopupData.pop3}
onChange={onChange}               
/>

<InputCheckbox label="Autenticacao" name="autenticacao" checked={operadoremailpopupData.autenticacao} onChange={onChange} />
        
<Input
type="text"
id="descricao"
label="Descricao"
className="inputIncNome"
name="descricao"
value={operadoremailpopupData.descricao}
onChange={onChange}               
/>

<Input
type="text"
id="usuario"
label="Usuario"
className="inputIncNome"
name="usuario"
value={operadoremailpopupData.usuario}
onChange={onChange}               
/>

<Input
type="text"
id="portasmtp"
label="PortaSmtp"
className="inputIncNome"
name="portasmtp"
value={operadoremailpopupData.portasmtp}
onChange={onChange}               
/>

<Input
type="text"
id="portapop3"
label="PortaPop3"
className="inputIncNome"
name="portapop3"
value={operadoremailpopupData.portapop3}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="assinatura"
label="Assinatura"
className="inputIncNome"
name="assinatura"
value={operadoremailpopupData.assinatura}
onChange={onChange}               
/>

<Input
autoComplete="off"
type="password"
id="senha256"
label="Senha256"
className="inputIncNome"
name="senha256"
value={operadoremailpopupData.senha256}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 