﻿"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IAgendaStatus } from '../../Interfaces/interface.AgendaStatus';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';

interface AgendaStatusFormProps {
    agendastatusData: IAgendaStatus;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaStatusForm: React.FC<AgendaStatusFormProps> = ({
    agendastatusData,
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

  if (agendastatusData.id === 0) {
    agendastatusData.agenda = getParamFromUrl("agenda");
  }
}
 const addValorAgenda = (e: any) => {
                        if (e?.id>0)
                        agendastatusData.agenda = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeAgenda && (<h2>{nomeAgenda}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <AgendaComboBox
            name={'agenda'}
            value={agendastatusData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

<Input
type="text"
id="completed"
label="Completed"
className="inputIncNome"
name="completed"
value={agendastatusData.completed}
onChange={onChange}               
/>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 