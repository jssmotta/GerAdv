// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IPenhora } from '@/app/GerAdv_TS/Penhora/Interfaces/interface.Penhora';
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
import PenhoraStatusComboBox from '@/app/GerAdv_TS/PenhoraStatus/ComboBox/PenhoraStatus';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { PenhoraStatusApi } from '@/app/GerAdv_TS/PenhoraStatus/Apis/ApiPenhoraStatus';
import InputName from '@/app/components/Inputs/InputName';

interface PenhoraFormProps {
    penhoraData: IPenhora;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const PenhoraForm: React.FC<PenhoraFormProps> = ({
    penhoraData,
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
const [nomePenhoraStatus, setNomePenhoraStatus] = useState('');
            const penhorastatusApi = new PenhoraStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (penhoraData.id === 0) {
    penhoraData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("penhorastatus") > 0) {
  penhorastatusApi
    .getById(getParamFromUrl("penhorastatus"))
    .then((response) => {
      setNomePenhoraStatus(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (penhoraData.id === 0) {
    penhoraData.penhorastatus = getParamFromUrl("penhorastatus");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        penhoraData.processo = e.id;
                      };
 const addValorPenhoraStatus = (e: any) => {
                        if (e?.id>0)
                        penhoraData.penhorastatus = e.id;
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
      const formElement = document.getElementById('PenhoraForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`PenhoraForm-${penhoraData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={penhoraData} isSubmitting={isSubmitting} onClose={onClose} formId={`PenhoraForm-${penhoraData.id}`} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={penhoraData.nome}
            placeholder={`Digite nome penhora`}
            onChange={onChange}
            required
          />

            <ProcessosComboBox
            name={'processo'}
            value={penhoraData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="descricao"
label="Descricao"
className="inputIncNome"
name="descricao"
value={penhoraData.descricao}
onChange={onChange}               
/>

<Input
type="text"
id="datapenhora"
label="DataPenhora"
className="inputIncNome"
name="datapenhora"
value={penhoraData.datapenhora}
onChange={onChange}               
/>

            <PenhoraStatusComboBox
            name={'penhorastatus'}
            value={penhoraData.penhorastatus}
            setValue={addValorPenhoraStatus}
            label={'Penhora Status'}
            />

<Input
type="text"
id="master"
label="Master"
className="inputIncNome"
name="master"
value={penhoraData.master}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 