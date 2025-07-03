// Tracking: Forms.tsx.txt
'use client';
import { IEnderecos } from '@/app/GerAdv_TS/Enderecos/Interfaces/interface.Enderecos';
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
import { EnderecosApi } from '../../Apis/ApiEnderecos';
import { useValidationsEnderecos } from '../../Hooks/hookEnderecos';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputDescription from '@/app/components/Inputs/InputDescription';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'
interface EnderecosFormProps {
  enderecosData: IEnderecos;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const EnderecosForm: React.FC<EnderecosFormProps> = ({
  enderecosData, 
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
const dadoApi = new EnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsEnderecos();
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('cidade') > 0) {
  if (enderecosData.id === 0 && enderecosData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    enderecosData.cidade = getParamFromUrl('cidade');
  }
}
const addValorCidade = (e: any) => {
  if (e?.id>0)
    enderecosData.cidade = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Enderecos:', error);
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
          target: document.getElementById(`EnderecosForm-${enderecosData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Enderecos diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = enderecosData?.id == 0 ? 'Editar Enderecos' : 'Adicionar Endereço';
    }
  }, [enderecosData.id]);
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

    <div className={isMobile ? 'form-container form-container-Enderecos' : 'form-container form-container-Enderecos'}>

      <form className='formInputCadInc' id={`EnderecosForm-${enderecosData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Enderecos' data={enderecosData} isSubmitting={isSubmitting} onClose={onClose} formId={`EnderecosForm-${enderecosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputDescription
            type='text'
            id='descricao'
            label='endereço'
            dataForm={enderecosData}
            className='inputIncNome'
            name='descricao'
            value={enderecosData.descricao}
            placeholder={`Digite nome endereço`}
            onChange={onChange}
            required
            disabled={enderecosData.id > 0}
            />
            <InputCheckbox dataForm={enderecosData} label='TopIndex' name='topindex' checked={enderecosData.topindex} onChange={onChange} />

            <InputInput
            type='text'
            maxLength={2147483647}
            id='contato'
            label='Contato'
            dataForm={enderecosData}
            className='inputIncNome'
            name='contato'
            value={enderecosData.contato}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='dtnasc'
            label='DtNasc'
            dataForm={enderecosData}
            className='inputIncNome'
            name='dtnasc'
            value={enderecosData.dtnasc}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={50}
            id='endereco'
            label='Endereco'
            dataForm={enderecosData}
            className='inputIncNome'
            name='endereco'
            value={enderecosData.endereco}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={30}
            id='bairro'
            label='Bairro'
            dataForm={enderecosData}
            className='inputIncNome'
            name='bairro'
            value={enderecosData.bairro}
            onChange={onChange}
            />

            <InputCheckbox dataForm={enderecosData} label='Privativo' name='privativo' checked={enderecosData.privativo} onChange={onChange} />
            <InputCheckbox dataForm={enderecosData} label='AddContato' name='addcontato' checked={enderecosData.addcontato} onChange={onChange} />

            <InputCep
            type='text'
            id='cep'
            label='CEP'
            dataForm={enderecosData}
            className='inputIncNome'
            name='cep'
            value={enderecosData.cep}
            onChange={onChange}
            />

          </div><div className='grid-container'>
            <InputInput
            type='text'
            maxLength={20}
            id='oab'
            label='OAB'
            dataForm={enderecosData}
            className='inputIncNome'
            name='oab'
            value={enderecosData.oab}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='obs'
            label='OBS'
            dataForm={enderecosData}
            className='inputIncNome'
            name='obs'
            value={enderecosData.obs}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='fone'
            label='Fone'
            dataForm={enderecosData}
            className='inputIncNome'
            name='fone'
            value={enderecosData.fone}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='fax'
            label='Fax'
            dataForm={enderecosData}
            className='inputIncNome'
            name='fax'
            value={enderecosData.fax}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={20}
            id='tratamento'
            label='Tratamento'
            dataForm={enderecosData}
            className='inputIncNome'
            name='tratamento'
            value={enderecosData.tratamento}
            onChange={onChange}
            />


            <CidadeComboBox
            name={'cidade'}
            dataForm={enderecosData}
            value={enderecosData.cidade}
            setValue={addValorCidade}
            label={'Cidade'}
            />

            <InputInput
            type='text'
            maxLength={200}
            id='site'
            label='Site'
            dataForm={enderecosData}
            className='inputIncNome'
            name='site'
            value={enderecosData.site}
            onChange={onChange}
            />


            <InputInput
            type='email'
            maxLength={255}
            id='email'
            label='EMail'
            dataForm={enderecosData}
            className='inputIncNome'
            name='email'
            value={enderecosData.email}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='quem'
            label='Quem'
            dataForm={enderecosData}
            className='inputIncNome'
            name='quem'
            value={enderecosData.quem}
            onChange={onChange}
            />

          </div><div className='grid-container'>
            <InputInput
            type='text'
            maxLength={150}
            id='quemindicou'
            label='QuemIndicou'
            dataForm={enderecosData}
            className='inputIncNome'
            name='quemindicou'
            value={enderecosData.quemindicou}
            onChange={onChange}
            />

            <InputCheckbox dataForm={enderecosData} label='ReportECBOnly' name='reportecbonly' checked={enderecosData.reportecbonly} onChange={onChange} />
            <InputCheckbox dataForm={enderecosData} label='Ani' name='ani' checked={enderecosData.ani} onChange={onChange} />
          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Enderecos' data={enderecosData} isSubmitting={isSubmitting} onClose={onClose} formId={`EnderecosForm-${enderecosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/enderecos'} id={enderecosData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };