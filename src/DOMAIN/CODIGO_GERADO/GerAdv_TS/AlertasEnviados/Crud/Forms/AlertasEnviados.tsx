// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAlertasEnviados } from '@/app/GerAdv_TS/AlertasEnviados/Interfaces/interface.AlertasEnviados';
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
import AlertasComboBox from '@/app/GerAdv_TS/Alertas/ComboBox/Alertas';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { AlertasApi } from '@/app/GerAdv_TS/Alertas/Apis/ApiAlertas';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface AlertasEnviadosFormProps {
    alertasenviadosData: IAlertasEnviados;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AlertasEnviadosForm: React.FC<AlertasEnviadosFormProps> = ({
    alertasenviadosData,
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
const [nomeAlertas, setNomeAlertas] = useState('');
            const alertasApi = new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (alertasenviadosData.id === 0) {
    alertasenviadosData.operador = getParamFromUrl("operador");
  }
}
 
if (getParamFromUrl("alertas") > 0) {
  alertasApi
    .getById(getParamFromUrl("alertas"))
    .then((response) => {
      setNomeAlertas(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (alertasenviadosData.id === 0) {
    alertasenviadosData.alerta = getParamFromUrl("alertas");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        alertasenviadosData.operador = e.id;
                      };
 const addValorAlerta = (e: any) => {
                        if (e?.id>0)
                        alertasenviadosData.alerta = e.id;
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
        console.error("Erro ao submeter formulário de AlertasEnviados:", error);
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
          target: document.getElementById(`AlertasEnviadosForm-${alertasenviadosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AlertasEnviados diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AlertasEnviados' : 'form-container5 form-container-AlertasEnviados'}>
       
            <form className='formInputCadInc' id={`AlertasEnviadosForm-${alertasenviadosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={alertasenviadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AlertasEnviadosForm-${alertasenviadosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <OperadorComboBox
            name={'operador'}
            value={alertasenviadosData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <AlertasComboBox
            name={'alerta'}
            value={alertasenviadosData.alerta}
            setValue={addValorAlerta}
            label={'Alertas'}
            />

<InputInput
type="text"
id="dataalertado"
label="DataAlertado"
className="inputIncNome"
name="dataalertado"
value={alertasenviadosData.dataalertado}
onChange={onChange}               
/>

<InputCheckbox label="Visualizado" name="visualizado" checked={alertasenviadosData.visualizado} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 