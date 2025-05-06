// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPontoVirtualAcessos } from '@/app/GerAdv_TS/PontoVirtualAcessos/Interfaces/interface.PontoVirtualAcessos';
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
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface PontoVirtualAcessosFormProps {
    pontovirtualacessosData: IPontoVirtualAcessos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PontoVirtualAcessosForm: React.FC<PontoVirtualAcessosFormProps> = ({
    pontovirtualacessosData,
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

  if (pontovirtualacessosData.id === 0) {
    pontovirtualacessosData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        pontovirtualacessosData.operador = e.id;
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
      const formElement = document.getElementById('PontoVirtualAcessosForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={pontovirtualacessosData} isSubmitting={isSubmitting} onClose={onClose} formId={`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`} />

                <div className="grid-container">

            <OperadorComboBox
            name={'operador'}
            value={pontovirtualacessosData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<Input
type="text"
id="datahora"
label="DataHora"
className="inputIncNome"
name="datahora"
value={pontovirtualacessosData.datahora}
onChange={onChange}               
/>

<InputCheckbox label="Tipo" name="tipo" checked={pontovirtualacessosData.tipo} onChange={onChange} />
        
<Input
type="text"
id="origem"
label="Origem"
className="inputIncNome"
name="origem"
value={pontovirtualacessosData.origem}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 