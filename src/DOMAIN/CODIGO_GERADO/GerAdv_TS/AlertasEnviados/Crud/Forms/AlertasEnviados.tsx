// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAlertasEnviados } from '@/app/GerAdv_TS/AlertasEnviados/Interfaces/interface.AlertasEnviados';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import AlertasComboBox from '@/app/GerAdv_TS/Alertas/ComboBox/Alertas';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { AlertasApi } from '@/app/GerAdv_TS/Alertas/Apis/ApiAlertas';
import InputName from '@/app/components/Inputs/InputName';
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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('AlertasEnviadosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`AlertasEnviadosForm-${alertasenviadosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={alertasenviadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AlertasEnviadosForm-${alertasenviadosData.id}`} />

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

<Input
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
        
    </>
     );
};
 