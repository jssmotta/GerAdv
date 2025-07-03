// Tracking: Forms.tsx.txt
'use client';
import { IFornecedores } from '@/app/GerAdv_TS/Fornecedores/Interfaces/interface.Fornecedores';
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
import { FornecedoresApi } from '../../Apis/ApiFornecedores';
import { useValidationsFornecedores } from '../../Hooks/hookFornecedores';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCnpj from '@/app/components/Inputs/InputCnpj'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'
interface FornecedoresFormProps {
  fornecedoresData: IFornecedores;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const FornecedoresForm: React.FC<FornecedoresFormProps> = ({
  fornecedoresData, 
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
const dadoApi = new FornecedoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsFornecedores();
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('cidade') > 0) {
  if (fornecedoresData.id === 0 && fornecedoresData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    fornecedoresData.cidade = getParamFromUrl('cidade');
  }
}
const addValorCidade = (e: any) => {
  if (e?.id>0)
    fornecedoresData.cidade = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Fornecedores:', error);
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
          target: document.getElementById(`FornecedoresForm-${fornecedoresData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Fornecedores diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = fornecedoresData?.id == 0 ? 'Editar Fornecedores' : 'Adicionar Fornecedor';
    }
  }, [fornecedoresData.id]);
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

    <div className={isMobile ? 'form-container form-container-Fornecedores' : 'form-container form-container-Fornecedores'}>

      <form className='formInputCadInc' id={`FornecedoresForm-${fornecedoresData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Fornecedores' data={fornecedoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`FornecedoresForm-${fornecedoresData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='nome'
            label='Nome'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='nome'
            value={fornecedoresData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
            />

            <InputInput
            type='text'
            maxLength={2048}
            id='grupo'
            label='Grupo'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='grupo'
            value={fornecedoresData.grupo}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='subgrupo'
            label='SubGrupo'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='subgrupo'
            value={fornecedoresData.subgrupo}
            onChange={onChange}
            />

            <InputCheckbox dataForm={fornecedoresData} label='Tipo' name='tipo' checked={fornecedoresData.tipo} onChange={onChange} />
            <InputCheckbox dataForm={fornecedoresData} label='Sexo' name='sexo' checked={fornecedoresData.sexo} onChange={onChange} />

            <InputCnpj
            type='text'
            id='cnpj'
            label='CNPJ'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='cnpj'
            value={fornecedoresData.cnpj}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={15}
            id='inscest'
            label='InscEst'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='inscest'
            value={fornecedoresData.inscest}
            onChange={onChange}
            />


            <InputCpf
            type='text'
            id='cpf'
            label='CPF'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='cpf'
            value={fornecedoresData.cpf}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={30}
            id='rg'
            label='RG'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='rg'
            value={fornecedoresData.rg}
            onChange={onChange}
            />

          </div><div className='grid-container'>
            <InputInput
            type='text'
            maxLength={80}
            id='endereco'
            label='Endereco'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='endereco'
            value={fornecedoresData.endereco}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={50}
            id='bairro'
            label='Bairro'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='bairro'
            value={fornecedoresData.bairro}
            onChange={onChange}
            />


            <InputCep
            type='text'
            id='cep'
            label='CEP'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='cep'
            value={fornecedoresData.cep}
            onChange={onChange}
            />


            <CidadeComboBox
            name={'cidade'}
            dataForm={fornecedoresData}
            value={fornecedoresData.cidade}
            setValue={addValorCidade}
            label={'Cidade'}
            />

            <InputInput
            type='text'
            maxLength={2147483647}
            id='fone'
            label='Fone'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='fone'
            value={fornecedoresData.fone}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='fax'
            label='Fax'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='fax'
            value={fornecedoresData.fax}
            onChange={onChange}
            />


            <InputInput
            type='email'
            maxLength={150}
            id='email'
            label='Email'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='email'
            value={fornecedoresData.email}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={150}
            id='site'
            label='Site'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='site'
            value={fornecedoresData.site}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='obs'
            label='Obs'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='obs'
            value={fornecedoresData.obs}
            onChange={onChange}
            />

          </div><div className='grid-container'>
            <InputInput
            type='text'
            maxLength={2147483647}
            id='produtos'
            label='Produtos'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='produtos'
            value={fornecedoresData.produtos}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='contatos'
            label='Contatos'
            dataForm={fornecedoresData}
            className='inputIncNome'
            name='contatos'
            value={fornecedoresData.contatos}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Fornecedores' data={fornecedoresData} isSubmitting={isSubmitting} onClose={onClose} formId={`FornecedoresForm-${fornecedoresData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/fornecedores'} id={fornecedoresData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };