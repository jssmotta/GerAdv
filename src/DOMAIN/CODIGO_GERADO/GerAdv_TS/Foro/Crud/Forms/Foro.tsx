// Tracking: Forms.tsx.txt
'use client';
import { IForo } from '@/app/GerAdv_TS/Foro/Interfaces/interface.Foro';
import { useRouter } from 'next/navigation';
import React, { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { ForoApi } from '../../Apis/ApiForo';
import { useValidationsForo } from '../../Hooks/hookForo';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCep from '@/app/components/Inputs/InputCep'
interface ForoFormProps {
  foroData: IForo;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ForoForm: React.FC<ForoFormProps> = ({
  foroData, 
  onChange, 
  onSubmit, 
  onClose, 
  onError, 
  onReload, 
  onSuccess, 
}) => {
const router = useRouter();
const { systemContext } = useSystemContext();
const isMobile = useIsMobile();
const dadoApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsForo();
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('cidade') > 0) {
  if (foroData.id === 0 && foroData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    foroData.cidade = getParamFromUrl('cidade');
  }
}
const addValorCidade = (e: any) => {
  if (e?.id>0)
    foroData.cidade = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Foro:', error);
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
          target: document.getElementById(`ForoForm-${foroData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Foro diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = foroData?.id == 0 ? 'Editar Foro' : 'Adicionar Foro';
    }
  }, [foroData.id]);
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

    <div className={isMobile ? 'form-container form-container-Foro' : 'form-container form-container-Foro'}>

      <form className='formInputCadInc' id={`ForoForm-${foroData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Foro' data={foroData} isSubmitting={isSubmitting} onClose={onClose} formId={`ForoForm-${foroData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='nome'
            label='Nome'
            dataForm={foroData}
            className='inputIncNome'
            name='nome'
            value={foroData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
            />

            <InputInput
            type='email'
            maxLength={150}
            id='email'
            label='EMail'
            dataForm={foroData}
            className='inputIncNome'
            name='email'
            value={foroData.email}
            onChange={onChange}
            />

            <InputCheckbox dataForm={foroData} label='Unico' name='unico' checked={foroData.unico} onChange={onChange} />

            <CidadeComboBox
            name={'cidade'}
            dataForm={foroData}
            value={foroData.cidade}
            setValue={addValorCidade}
            label={'Cidade'}
            />

            <InputInput
            type='text'
            maxLength={150}
            id='site'
            label='Site'
            dataForm={foroData}
            className='inputIncNome'
            name='site'
            value={foroData.site}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={50}
            id='endereco'
            label='Endereco'
            dataForm={foroData}
            className='inputIncNome'
            name='endereco'
            value={foroData.endereco}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={255}
            id='bairro'
            label='Bairro'
            dataForm={foroData}
            className='inputIncNome'
            name='bairro'
            value={foroData.bairro}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='fone'
            label='Fone'
            dataForm={foroData}
            className='inputIncNome'
            name='fone'
            value={foroData.fone}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='fax'
            label='Fax'
            dataForm={foroData}
            className='inputIncNome'
            name='fax'
            value={foroData.fax}
            onChange={onChange}
            />

          </div><div className='grid-container'>
            <InputCep
            type='text'
            id='cep'
            label='CEP'
            dataForm={foroData}
            className='inputIncNome'
            name='cep'
            value={foroData.cep}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='obs'
            label='OBS'
            dataForm={foroData}
            className='inputIncNome'
            name='obs'
            value={foroData.obs}
            onChange={onChange}
            />

            <InputCheckbox dataForm={foroData} label='UnicoConfirmado' name='unicoconfirmado' checked={foroData.unicoconfirmado} onChange={onChange} />

            <InputInput
            type='text'
            maxLength={255}
            id='web'
            label='Web'
            dataForm={foroData}
            className='inputIncNome'
            name='web'
            value={foroData.web}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Foro' data={foroData} isSubmitting={isSubmitting} onClose={onClose} formId={`ForoForm-${foroData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/foro'} id={foroData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };