// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IReuniaoPessoas } from '@/app/GerAdv_TS/ReuniaoPessoas/Interfaces/interface.ReuniaoPessoas';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ReuniaoComboBox from '@/app/GerAdv_TS/Reuniao/ComboBox/Reuniao';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { ReuniaoApi } from '@/app/GerAdv_TS/Reuniao/Apis/ApiReuniao';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';

interface ReuniaoPessoasFormProps {
    reuniaopessoasData: IReuniaoPessoas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ReuniaoPessoasForm: React.FC<ReuniaoPessoasFormProps> = ({
    reuniaopessoasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeReuniao, setNomeReuniao] = useState('');
            const reuniaoApi = new ReuniaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
            const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("reuniao") > 0) {
  reuniaoApi
    .getById(getParamFromUrl("reuniao"))
    .then((response) => {
      setNomeReuniao(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (reuniaopessoasData.id === 0) {
    reuniaopessoasData.reuniao = getParamFromUrl("reuniao");
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

  if (reuniaopessoasData.id === 0) {
    reuniaopessoasData.operador = getParamFromUrl("operador");
  }
}
 const addValorReuniao = (e: any) => {
                        if (e?.id>0)
                        reuniaopessoasData.reuniao = e.id;
                      };
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        reuniaopessoasData.operador = e.id;
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
      const formElement = document.getElementById('ReuniaoPessoasForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`ReuniaoPessoasForm-${reuniaopessoasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={reuniaopessoasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ReuniaoPessoasForm-${reuniaopessoasData.id}`} />

                <div className="grid-container">

            <ReuniaoComboBox
            name={'reuniao'}
            value={reuniaopessoasData.reuniao}
            setValue={addValorReuniao}
            label={'Reuniao'}
            />

            <OperadorComboBox
            name={'operador'}
            value={reuniaopessoasData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 