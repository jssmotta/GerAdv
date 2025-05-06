// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAndamentosMD } from '@/app/GerAdv_TS/AndamentosMD/Interfaces/interface.AndamentosMD';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';

interface AndamentosMDFormProps {
    andamentosmdData: IAndamentosMD;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AndamentosMDForm: React.FC<AndamentosMDFormProps> = ({
    andamentosmdData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (andamentosmdData.id === 0) {
    andamentosmdData.processo = getParamFromUrl("processos");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        andamentosmdData.processo = e.id;
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
      const formElement = document.getElementById('AndamentosMDForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`AndamentosMDForm-${andamentosmdData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={andamentosmdData} isSubmitting={isSubmitting} onClose={onClose} formId={`AndamentosMDForm-${andamentosmdData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={andamentosmdData.nome}
            placeholder={`Digite nome andamentos m d`}
            onChange={onChange}
            required
          />

            <ProcessosComboBox
            name={'processo'}
            value={andamentosmdData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="andamento"
label="Andamento"
className="inputIncNome"
name="andamento"
value={andamentosmdData.andamento}
onChange={onChange}               
/>

<Input
type="text"
id="pathfull"
label="PathFull"
className="inputIncNome"
name="pathfull"
value={andamentosmdData.pathfull}
onChange={onChange}               
/>

<Input
type="text"
id="unc"
label="UNC"
className="inputIncNome"
name="unc"
value={andamentosmdData.unc}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 