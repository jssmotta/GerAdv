// Tracking: Forms.tsx.txt
'use client';
import { IFuncionarios } from '@/app/GerAdv_TS/Funcionarios/Interfaces/interface.Funcionarios';
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
import { FuncionariosApi } from '../../Apis/ApiFuncionarios';
import { useValidationsFuncionarios } from '../../Hooks/hookFuncionarios';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import InputName from '@/app/components/Inputs/InputName';
import InputSexo from '@/app/components/Inputs/InputSexo'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'
import InputTelefone from '@/app/components/Inputs/InputTelefone'
import InputEmail from '@/app/components/Inputs/InputEmail'
import InputDate from '@/app/components/Inputs/InputDate'
import InputMemo from '@/app/components/Inputs/InputMemo'
interface FuncionariosFormProps {
  funcionariosData: IFuncionarios;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const FuncionariosForm: React.FC<FuncionariosFormProps> = ({
  funcionariosData, 
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
const dadoApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsFuncionarios();
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeCargos, setNomeCargos] = useState('');
const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('cidade') > 0) {
  if (funcionariosData.id === 0 && funcionariosData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    funcionariosData.cidade = getParamFromUrl('cidade');
  }
}

if (getParamFromUrl('cargos') > 0) {
  if (funcionariosData.id === 0 && funcionariosData.cargo == 0) {
    cargosApi
    .getById(getParamFromUrl('cargos'))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    funcionariosData.cargo = getParamFromUrl('cargos');
  }
}
const addValorCidade = (e: any) => {
  if (e?.id>0)
    funcionariosData.cidade = e.id;
  };
  const addValorCargo = (e: any) => {
    if (e?.id>0)
      funcionariosData.cargo = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de Funcionarios:', error);
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
            target: document.getElementById(`FuncionariosForm-${funcionariosData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar Funcionarios diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = funcionariosData?.id == 0 ? 'Editar Funcionarios' : 'Adicionar Colaborador';
      }
    }, [funcionariosData.id]);
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

      <div className={isMobile ? 'form-container form-container-Funcionarios' : 'form-container form-container-Funcionarios'}>

        <form className='formInputCadInc' id={`FuncionariosForm-${funcionariosData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Funcionarios' data={funcionariosData} isSubmitting={isSubmitting} onClose={onClose} formId={`FuncionariosForm-${funcionariosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputName
              type='text'
              id='nome'
              label='Nome'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='nome'
              value={funcionariosData.nome}
              placeholder={`Informe Nome`}
              onChange={onChange}
              required
              />

              <InputSexo
              type='text'
              id='sexo'
              label='Sexo'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='sexo'
              value={funcionariosData.sexo}
              onChange={onChange}
              />


              <InputCpf
              type='text'
              id='cpf'
              label='CPF'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='cpf'
              value={funcionariosData.cpf}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={30}
              id='rg'
              label='RG'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='rg'
              value={funcionariosData.rg}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={80}
              id='endereco'
              label='Endereço'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='endereco'
              value={funcionariosData.endereco}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={50}
              id='bairro'
              label='Bairro'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='bairro'
              value={funcionariosData.bairro}
              onChange={onChange}
              />


              <CidadeComboBox
              name={'cidade'}
              dataForm={funcionariosData}
              value={funcionariosData.cidade}
              setValue={addValorCidade}
              label={'Cidade'}
              />

              <InputCep
              type='text'
              id='cep'
              label='CEP'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='cep'
              value={funcionariosData.cep}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2147483647}
              id='contato'
              label='Contato'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='contato'
              value={funcionariosData.contato}
              onChange={onChange}
              />

            </div><div className='grid-container'>
              <InputTelefone
              type='text'
              maxLength={2147483647}
              id='fone'
              label='Fone'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='fone'
              value={funcionariosData.fone}
              onChange={onChange}
              />


              <InputEmail
              type='email'
              maxLength={60}
              id='email'
              label='E-mail'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='email'
              value={funcionariosData.email}
              onChange={onChange}
              />


              <InputDate
              type='text'
              id='dtnasc'
              label='Data Nasc.'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='dtnasc'
              value={funcionariosData.dtnasc}
              onChange={(date: string) =>
                onChange({
                  target: {
                    name: 'dtnasc',
                    value: date, 
                  }, 
                })
              }
              />


              <CargosComboBox
              name={'cargo'}
              dataForm={funcionariosData}
              value={funcionariosData.cargo}
              setValue={addValorCargo}
              label={'Cargo'}
              />

              <InputMemo
              type='text'
              maxLength={2147483647}
              id='observacao'
              label='Observações'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='observacao'
              value={funcionariosData.observacao}
              onChange={onChange}
              />

            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Funcionarios' data={funcionariosData} isSubmitting={isSubmitting} onClose={onClose} formId={`FuncionariosForm-${funcionariosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/funcionarios'} id={funcionariosData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };