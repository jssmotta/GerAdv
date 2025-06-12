// Tracking: Forms.tsx.txt
'use client';
import { IAgendaStatus } from '@/app/GerAdv_TS/AgendaStatus/Interfaces/interface.AgendaStatus';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { AgendaStatusApi } from '../../Apis/ApiAgendaStatus';
import { useValidationsAgendaStatus } from '../../Hooks/hookAgendaStatus';
import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface AgendaStatusFormProps {
  agendastatusData: IAgendaStatus;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AgendaStatusForm: React.FC<AgendaStatusFormProps> = ({
  agendastatusData, 
  onChange, 
  onSubmit, 
  onClose, 
  onError, 
  onReload, 
  onSuccess, 
}) => {
const router = useRouter();
const isMobile = useIsMobile();
const { systemContext } = useSystemContext();
const dadoApi = new AgendaStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAgendaStatus();
const [nomeAgenda, setNomeAgenda] = useState('');
const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('agenda') > 0) {
  if (agendastatusData.id === 0 && agendastatusData.agenda == 0) {
    agendaApi
    .getById(getParamFromUrl('agenda'))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    agendastatusData.agenda = getParamFromUrl('agenda');
  }
}
const addValorAgenda = (e: any) => {
  if (e?.id>0)
    agendastatusData.agenda = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de AgendaStatus:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    const handleCancel = () => {
      if (onReload) {
        onReload(); // Recarrega os dados originais
      } else {
      onClose(); // Comportamento padrão se não há callback de recarga
    }
  };

  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        const syntheticEvent = {
          preventDefault: () => { }, 
          target: document.getElementById(`AgendaStatusForm-${agendastatusData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar AgendaStatus diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = agendastatusData?.id == 0 ? 'Editar AgendaStatus' : 'Adicionar Agenda Status';
    }
  }, [agendastatusData.id]);
  return (
  <>
  <style>
    {!isMobile ? `
      @media (max-width: 1366px) {
        html {
          zoom: 0.8 !important;
        }
      }
      ` : ``}
    </style>

    <div className={isMobile ? 'form-container form-container-AgendaStatus' : 'form-container5 form-container-AgendaStatus'}>

      <form className='formInputCadInc' id={`AgendaStatusForm-${agendastatusData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AgendaStatus' data={agendastatusData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaStatusForm-${agendastatusData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>


            <AgendaComboBox
            name={'agenda'}
            dataForm={agendastatusData}
            value={agendastatusData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />

            <InputInput
            type='text'
            maxLength={2048}
            id='completed'
            label='Completed'
            dataForm={agendastatusData}
            className='inputIncNome'
            name='completed'
            value={agendastatusData.completed}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AgendaStatus' data={agendastatusData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaStatusForm-${agendastatusData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/agendastatus'} id={agendastatusData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };