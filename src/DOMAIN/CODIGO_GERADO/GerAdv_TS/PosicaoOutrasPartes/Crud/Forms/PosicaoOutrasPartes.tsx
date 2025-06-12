// Tracking: Forms.tsx.txt
'use client';
import { IPosicaoOutrasPartes } from '@/app/GerAdv_TS/PosicaoOutrasPartes/Interfaces/interface.PosicaoOutrasPartes';
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
import { PosicaoOutrasPartesApi } from '../../Apis/ApiPosicaoOutrasPartes';
import { useValidationsPosicaoOutrasPartes } from '../../Hooks/hookPosicaoOutrasPartes';
import InputDescription from '@/app/components/Inputs/InputDescription';
interface PosicaoOutrasPartesFormProps {
  posicaooutraspartesData: IPosicaoOutrasPartes;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const PosicaoOutrasPartesForm: React.FC<PosicaoOutrasPartesFormProps> = ({
  posicaooutraspartesData, 
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
const dadoApi = new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsPosicaoOutrasPartes();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de PosicaoOutrasPartes:', error);
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
        target: document.getElementById(`PosicaoOutrasPartesForm-${posicaooutraspartesData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar PosicaoOutrasPartes diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = posicaooutraspartesData?.id == 0 ? 'Editar PosicaoOutrasPartes' : 'Adicionar Posicao Outras Partes';
  }
}, [posicaooutraspartesData.id]);
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

  <div className={isMobile ? 'form-container form-container-PosicaoOutrasPartes' : 'form-container5 form-container-PosicaoOutrasPartes'}>

    <form className='formInputCadInc' id={`PosicaoOutrasPartesForm-${posicaooutraspartesData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='PosicaoOutrasPartes' data={posicaooutraspartesData} isSubmitting={isSubmitting} onClose={onClose} formId={`PosicaoOutrasPartesForm-${posicaooutraspartesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputDescription
          type='text'
          id='descricao'
          label='posicao outras partes'
          dataForm={posicaooutraspartesData}
          className='inputIncNome'
          name='descricao'
          value={posicaooutraspartesData.descricao}
          placeholder={`Digite nome posicao outras partes`}
          onChange={onChange}
          required
          disabled={posicaooutraspartesData.id > 0}
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='PosicaoOutrasPartes' data={posicaooutraspartesData} isSubmitting={isSubmitting} onClose={onClose} formId={`PosicaoOutrasPartesForm-${posicaooutraspartesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/posicaooutraspartes'} id={posicaooutraspartesData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };