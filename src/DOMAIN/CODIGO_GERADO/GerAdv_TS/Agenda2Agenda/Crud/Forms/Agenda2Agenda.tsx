// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgenda2Agenda } from '@/app/GerAdv_TS/Agenda2Agenda/Interfaces/interface.Agenda2Agenda';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import InputName from '@/app/components/Inputs/InputName';

interface Agenda2AgendaFormProps {
    agenda2agendaData: IAgenda2Agenda;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const Agenda2AgendaForm: React.FC<Agenda2AgendaFormProps> = ({
    agenda2agendaData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAgenda, setNomeAgenda] = useState('');
            const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("agenda") > 0) {
  agendaApi
    .getById(getParamFromUrl("agenda"))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agenda2agendaData.id === 0) {
    agenda2agendaData.agenda = getParamFromUrl("agenda");
  }
}
 const addValorAgenda = (e: any) => {
                        if (e?.id>0)
                        agenda2agendaData.agenda = e.id;
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
      const formElement = document.getElementById('Agenda2AgendaForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`Agenda2AgendaForm-${agenda2agendaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agenda2agendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`Agenda2AgendaForm-${agenda2agendaData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="master"
label="Master"
className="inputIncNome"
name="master"
value={agenda2agendaData.master}
onChange={onChange}               
/>

            <AgendaComboBox
            name={'agenda'}
            value={agenda2agendaData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 