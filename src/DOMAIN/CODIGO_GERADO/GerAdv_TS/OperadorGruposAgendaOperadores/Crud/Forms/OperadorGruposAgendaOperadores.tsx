// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperadorGruposAgendaOperadores } from '@/app/GerAdv_TS/OperadorGruposAgendaOperadores/Interfaces/interface.OperadorGruposAgendaOperadores';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import OperadorGruposAgendaComboBox from '@/app/GerAdv_TS/OperadorGruposAgenda/ComboBox/OperadorGruposAgenda';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorGruposAgendaApi } from '@/app/GerAdv_TS/OperadorGruposAgenda/Apis/ApiOperadorGruposAgenda';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';

interface OperadorGruposAgendaOperadoresFormProps {
    operadorgruposagendaoperadoresData: IOperadorGruposAgendaOperadores;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorGruposAgendaOperadoresForm: React.FC<OperadorGruposAgendaOperadoresFormProps> = ({
    operadorgruposagendaoperadoresData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeOperadorGruposAgenda, setNomeOperadorGruposAgenda] = useState('');
            const operadorgruposagendaApi = new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("operadorgruposagenda") > 0) {
  operadorgruposagendaApi
    .getById(getParamFromUrl("operadorgruposagenda"))
    .then((response) => {
      setNomeOperadorGruposAgenda(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadorgruposagendaoperadoresData.id === 0) {
    operadorgruposagendaoperadoresData.operadorgruposagenda = getParamFromUrl("operadorgruposagenda");
  }
}
 
if (getParamFromUrl("operador") > 0) {
  operadorApi
    .getById(getParamFromUrl("operador"))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (operadorgruposagendaoperadoresData.id === 0) {
    operadorgruposagendaoperadoresData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperadorGruposAgenda = (e: any) => {
                        if (e?.id>0)
                        operadorgruposagendaoperadoresData.operadorgruposagenda = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        operadorgruposagendaoperadoresData.operador = e.id;
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
      const formElement = document.getElementById('OperadorGruposAgendaOperadoresForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadorgruposagendaoperadoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposAgendaOperadoresForm-${operadorgruposagendaoperadoresData.id}`} />

                <div className="grid-container">

            <OperadorGruposAgendaComboBox
            name={'operadorgruposagenda'}
            value={operadorgruposagendaoperadoresData.operadorgruposagenda}
            setValue={addValorOperadorGruposAgenda}
            label={'Operador Grupos Agenda'}
            />

            <OperadorComboBox
            name={'operador'}
            value={operadorgruposagendaoperadoresData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 