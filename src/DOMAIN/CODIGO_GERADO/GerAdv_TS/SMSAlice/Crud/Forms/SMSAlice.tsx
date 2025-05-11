// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { ISMSAlice } from '@/app/GerAdv_TS/SMSAlice/Interfaces/interface.SMSAlice';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import TipoEMailComboBox from '@/app/GerAdv_TS/TipoEMail/ComboBox/TipoEMail';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { TipoEMailApi } from '@/app/GerAdv_TS/TipoEMail/Apis/ApiTipoEMail';
import InputName from '@/app/components/Inputs/InputName';

interface SMSAliceFormProps {
    smsaliceData: ISMSAlice;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const SMSAliceForm: React.FC<SMSAliceFormProps> = ({
    smsaliceData,
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
const [nomeTipoEMail, setNomeTipoEMail] = useState('');
            const tipoemailApi = new TipoEMailApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (smsaliceData.id === 0) {
    smsaliceData.operador = getParamFromUrl("operador");
  }
}
 
if (getParamFromUrl("tipoemail") > 0) {
  tipoemailApi
    .getById(getParamFromUrl("tipoemail"))
    .then((response) => {
      setNomeTipoEMail(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (smsaliceData.id === 0) {
    smsaliceData.tipoemail = getParamFromUrl("tipoemail");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        smsaliceData.operador = e.id;
                      };
 const addValorTipoEMail = (e: any) => {
                        if (e?.id>0)
                        smsaliceData.tipoemail = e.id;
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
        console.error("Erro ao submeter formulário de SMSAlice:", error);
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
          target: document.getElementById(`SMSAliceForm-${smsaliceData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar SMSAlice diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-SMSAlice' : 'form-container5 form-container-SMSAlice'}>
       
            <form className='formInputCadInc' id={`SMSAliceForm-${smsaliceData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={smsaliceData} isSubmitting={isSubmitting} onClose={onClose} formId={`SMSAliceForm-${smsaliceData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={smsaliceData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <OperadorComboBox
            name={'operador'}
            value={smsaliceData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <TipoEMailComboBox
            name={'tipoemail'}
            value={smsaliceData.tipoemail}
            setValue={addValorTipoEMail}
            label={'Tipo E Mail'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 