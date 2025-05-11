// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperadorEMailPopup } from '@/app/GerAdv_TS/OperadorEMailPopup/Interfaces/interface.OperadorEMailPopup';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
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
  const isMobile = useIsMobile();
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
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de OperadorEMailPopup:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`OperadorEMailPopupForm-${operadoremailpopupData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar OperadorEMailPopup diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-OperadorEMailPopup' : 'form-container form-container-OperadorEMailPopup'}>
       
            <form className='formInputCadInc' id={`OperadorEMailPopupForm-${operadoremailpopupData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadoremailpopupData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorEMailPopupForm-${operadoremailpopupData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={operadoremailpopupData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <OperadorComboBox
            name={'operador'}
            value={operadoremailpopupData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<InputInput
autoComplete="off"
type="password"
id="senha"
label="Senha"
className="inputIncNome"
name="senha"
value={operadoremailpopupData.senha}
onChange={onChange}               
/>

<InputInput
type="text"
id="smtp"
label="SMTP"
className="inputIncNome"
name="smtp"
value={operadoremailpopupData.smtp}
onChange={onChange}               
/>

<InputInput
type="text"
id="pop3"
label="POP3"
className="inputIncNome"
name="pop3"
value={operadoremailpopupData.pop3}
onChange={onChange}               
/>

<InputCheckbox label="Autenticacao" name="autenticacao" checked={operadoremailpopupData.autenticacao} onChange={onChange} />
        
<InputInput
type="text"
id="descricao"
label="Descricao"
className="inputIncNome"
name="descricao"
value={operadoremailpopupData.descricao}
onChange={onChange}               
/>

<InputInput
type="text"
id="usuario"
label="Usuario"
className="inputIncNome"
name="usuario"
value={operadoremailpopupData.usuario}
onChange={onChange}               
/>

<InputInput
type="text"
id="portasmtp"
label="PortaSmtp"
className="inputIncNome"
name="portasmtp"
value={operadoremailpopupData.portasmtp}
onChange={onChange}               
/>

<InputInput
type="text"
id="portapop3"
label="PortaPop3"
className="inputIncNome"
name="portapop3"
value={operadoremailpopupData.portapop3}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="assinatura"
label="Assinatura"
className="inputIncNome"
name="assinatura"
value={operadoremailpopupData.assinatura}
onChange={onChange}               
/>

<InputInput
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
        <div className="form-spacer"></div>
        
    </>
     );
};
 