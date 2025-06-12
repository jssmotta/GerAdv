// Tracking: Forms.tsx.txt
'use client';
import { ITipoModeloDocumento } from '@/app/GerAdv_TS/TipoModeloDocumento/Interfaces/interface.TipoModeloDocumento';
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
import { TipoModeloDocumentoApi } from '../../Apis/ApiTipoModeloDocumento';
import { useValidationsTipoModeloDocumento } from '../../Hooks/hookTipoModeloDocumento';
import InputName from '@/app/components/Inputs/InputName';
interface TipoModeloDocumentoFormProps {
  tipomodelodocumentoData: ITipoModeloDocumento;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TipoModeloDocumentoForm: React.FC<TipoModeloDocumentoFormProps> = ({
  tipomodelodocumentoData, 
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
const dadoApi = new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTipoModeloDocumento();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de TipoModeloDocumento:', error);
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
        target: document.getElementById(`TipoModeloDocumentoForm-${tipomodelodocumentoData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar TipoModeloDocumento diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = tipomodelodocumentoData?.id == 0 ? 'Editar TipoModeloDocumento' : 'Adicionar Tipo Modelo Documento';
  }
}, [tipomodelodocumentoData.id]);
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

  <div className={isMobile ? 'form-container form-container-TipoModeloDocumento' : 'form-container5 form-container-TipoModeloDocumento'}>

    <form className='formInputCadInc' id={`TipoModeloDocumentoForm-${tipomodelodocumentoData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='TipoModeloDocumento' data={tipomodelodocumentoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoModeloDocumentoForm-${tipomodelodocumentoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={tipomodelodocumentoData}
          className='inputIncNome'
          name='nome'
          value={tipomodelodocumentoData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='TipoModeloDocumento' data={tipomodelodocumentoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoModeloDocumentoForm-${tipomodelodocumentoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/tipomodelodocumento'} id={tipomodelodocumentoData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };