// Tracking: Forms.tsx.txt
'use client';
import { IContatoCRMView } from '@/app/GerAdv_TS/ContatoCRMView/Interfaces/interface.ContatoCRMView';
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
import { ContatoCRMViewApi } from '../../Apis/ApiContatoCRMView';
import { useValidationsContatoCRMView } from '../../Hooks/hookContatoCRMView';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ContatoCRMViewFormProps {
  contatocrmviewData: IContatoCRMView;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ContatoCRMViewForm: React.FC<ContatoCRMViewFormProps> = ({
  contatocrmviewData, 
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
const dadoApi = new ContatoCRMViewApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsContatoCRMView();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de ContatoCRMView:', error);
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
        target: document.getElementById(`ContatoCRMViewForm-${contatocrmviewData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar ContatoCRMView diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = contatocrmviewData?.id == 0 ? 'Editar ContatoCRMView' : 'Adicionar Contato C R M View';
  }
}, [contatocrmviewData.id]);
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

  <div className={isMobile ? 'form-container form-container-ContatoCRMView' : 'form-container5 form-container-ContatoCRMView'}>

    <form className='formInputCadInc' id={`ContatoCRMViewForm-${contatocrmviewData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ContatoCRMView' data={contatocrmviewData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMViewForm-${contatocrmviewData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>


          <InputInput
          type='text'
          maxLength={2048}
          id='data'
          label='Data'
          dataForm={contatocrmviewData}
          className='inputIncNome'
          name='data'
          value={contatocrmviewData.data}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={50}
          id='ip'
          label='IP'
          dataForm={contatocrmviewData}
          className='inputIncNome'
          name='ip'
          value={contatocrmviewData.ip}
          onChange={onChange}
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ContatoCRMView' data={contatocrmviewData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMViewForm-${contatocrmviewData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/contatocrmview'} id={contatocrmviewData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };