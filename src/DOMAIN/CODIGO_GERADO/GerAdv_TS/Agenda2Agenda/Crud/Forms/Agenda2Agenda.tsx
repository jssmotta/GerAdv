// Tracking: Forms.tsx.txt
'use client';
import { IAgenda2Agenda } from '@/app/GerAdv_TS/Agenda2Agenda/Interfaces/interface.Agenda2Agenda';
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
import { Agenda2AgendaApi } from '../../Apis/ApiAgenda2Agenda';
import { useValidationsAgenda2Agenda } from '../../Hooks/hookAgenda2Agenda';
import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface Agenda2AgendaFormProps {
  agenda2agendaData: IAgenda2Agenda;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const Agenda2AgendaForm: React.FC<Agenda2AgendaFormProps> = ({
  agenda2agendaData, 
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
const dadoApi = new Agenda2AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAgenda2Agenda();
const [nomeAgenda, setNomeAgenda] = useState('');
const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('agenda') > 0) {
  if (agenda2agendaData.id === 0 && agenda2agendaData.agenda == 0) {
    agendaApi
    .getById(getParamFromUrl('agenda'))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    agenda2agendaData.agenda = getParamFromUrl('agenda');
  }
}
const addValorAgenda = (e: any) => {
  if (e?.id>0)
    agenda2agendaData.agenda = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Agenda2Agenda:', error);
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
          target: document.getElementById(`Agenda2AgendaForm-${agenda2agendaData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Agenda2Agenda diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = agenda2agendaData?.id == 0 ? 'Editar Agenda2Agenda' : 'Adicionar Agenda2 Agenda';
    }
  }, [agenda2agendaData.id]);
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

    <div className={isMobile ? 'form-container form-container-Agenda2Agenda' : 'form-container5 form-container-Agenda2Agenda'}>

      <form className='formInputCadInc' id={`Agenda2AgendaForm-${agenda2agendaData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Agenda2Agenda' data={agenda2agendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`Agenda2AgendaForm-${agenda2agendaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>


            <InputInput
            type='text'
            maxLength={2048}
            id='master'
            label='Master'
            dataForm={agenda2agendaData}
            className='inputIncNome'
            name='master'
            value={agenda2agendaData.master}
            onChange={onChange}
            />


            <AgendaComboBox
            name={'agenda'}
            dataForm={agenda2agendaData}
            value={agenda2agendaData.agenda}
            setValue={addValorAgenda}
            label={'Agenda'}
            />
          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Agenda2Agenda' data={agenda2agendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`Agenda2AgendaForm-${agenda2agendaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/agenda2agenda'} id={agenda2agendaData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };