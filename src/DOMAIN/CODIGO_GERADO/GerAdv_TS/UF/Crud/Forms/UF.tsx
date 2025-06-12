// Tracking: Forms.tsx.txt
'use client';
import { IUF } from '@/app/GerAdv_TS/UF/Interfaces/interface.UF';
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
import { UFApi } from '../../Apis/ApiUF';
import { useValidationsUF } from '../../Hooks/hookUF';
import PaisesComboBox from '@/app/GerAdv_TS/Paises/ComboBox/Paises';
import { PaisesApi } from '@/app/GerAdv_TS/Paises/Apis/ApiPaises';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface UFFormProps {
  ufData: IUF;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const UFForm: React.FC<UFFormProps> = ({
  ufData, 
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
const dadoApi = new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsUF();
const [nomePaises, setNomePaises] = useState('');
const paisesApi = new PaisesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('paises') > 0) {
  if (ufData.id === 0 && ufData.pais == 0) {
    paisesApi
    .getById(getParamFromUrl('paises'))
    .then((response) => {
      setNomePaises(response.data.inome);
    })
    .catch((error) => {
      console.error(error);
    });

    ufData.pais = getParamFromUrl('paises');
  }
}
const addValorPais = (e: any) => {
  if (e?.id>0)
    ufData.pais = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de UF:', error);
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
          target: document.getElementById(`UFForm-${ufData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar UF diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = ufData?.id == 0 ? 'Editar UF' : 'Adicionar UF';
    }
  }, [ufData.id]);
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

    <div className={isMobile ? 'form-container form-container-UF' : 'form-container5 form-container-UF'}>

      <form className='formInputCadInc' id={`UFForm-${ufData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='UF' data={ufData} isSubmitting={isSubmitting} onClose={onClose} formId={`UFForm-${ufData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='iduf'
            label='ID'
            dataForm={ufData}
            className='inputIncNome'
            name='iduf'
            value={ufData.iduf}
            placeholder={`Informe ID`}
            onChange={onChange}
            required
            />

            <InputInput
            type='text'
            maxLength={10}
            id='ddd'
            label='DDD'
            dataForm={ufData}
            className='inputIncNome'
            name='ddd'
            value={ufData.ddd}
            onChange={onChange}
            />


            <PaisesComboBox
            name={'pais'}
            dataForm={ufData}
            value={ufData.pais}
            setValue={addValorPais}
            label={'Paises'}
            />
            <InputCheckbox dataForm={ufData} label='Top' name='top' checked={ufData.top} onChange={onChange} />

            <InputInput
            type='text'
            maxLength={40}
            id='descricao'
            label='Descricao'
            dataForm={ufData}
            className='inputIncNome'
            name='descricao'
            value={ufData.descricao}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='UF' data={ufData} isSubmitting={isSubmitting} onClose={onClose} formId={`UFForm-${ufData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/uf'} id={ufData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };