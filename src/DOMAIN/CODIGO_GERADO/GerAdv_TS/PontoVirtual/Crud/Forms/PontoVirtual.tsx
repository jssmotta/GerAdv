// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPontoVirtual } from '@/app/GerAdv_TS/PontoVirtual/Interfaces/interface.PontoVirtual';
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

interface PontoVirtualFormProps {
    pontovirtualData: IPontoVirtual;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PontoVirtualForm: React.FC<PontoVirtualFormProps> = ({
    pontovirtualData,
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

  if (pontovirtualData.id === 0) {
    pontovirtualData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        pontovirtualData.operador = e.id;
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
      const formElement = document.getElementById('PontoVirtualForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`PontoVirtualForm-${pontovirtualData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={pontovirtualData} isSubmitting={isSubmitting} onClose={onClose} formId={`PontoVirtualForm-${pontovirtualData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="horaentrada"
label="HoraEntrada"
className="inputIncNome"
name="horaentrada"
value={pontovirtualData.horaentrada}
onChange={onChange}               
/>

<Input
type="text"
id="horasaida"
label="HoraSaida"
className="inputIncNome"
name="horasaida"
value={pontovirtualData.horasaida}
onChange={onChange}               
/>

            <OperadorComboBox
            name={'operador'}
            value={pontovirtualData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<Input
type="text"
id="key"
label="Key"
className="inputIncNome"
name="key"
value={pontovirtualData.key}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 