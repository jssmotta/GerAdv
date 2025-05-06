// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IOperadorGrupo } from '@/app/GerAdv_TS/OperadorGrupo/Interfaces/interface.OperadorGrupo';
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

interface OperadorGrupoFormProps {
    operadorgrupoData: IOperadorGrupo;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorGrupoForm: React.FC<OperadorGrupoFormProps> = ({
    operadorgrupoData,
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

  if (operadorgrupoData.id === 0) {
    operadorgrupoData.operador = getParamFromUrl("operador");
  }
}
 const addValorOperador = (e: any) => {
                        if (e?.id>0)
                        operadorgrupoData.operador = e.id;
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
      const formElement = document.getElementById('OperadorGrupoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`OperadorGrupoForm-${operadorgrupoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={operadorgrupoData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGrupoForm-${operadorgrupoData.id}`} />

                <div className="grid-container">

            <OperadorComboBox
            name={'operador'}
            value={operadorgrupoData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

<Input
type="text"
id="grupo"
label="Grupo"
className="inputIncNome"
name="grupo"
value={operadorgrupoData.grupo}
onChange={onChange}               
/>

<InputCheckbox label="Inativo" name="inativo" checked={operadorgrupoData.inativo} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 