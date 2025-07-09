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
import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import FuncaoComboBox from '@/app/GerAdv_TS/Funcao/ComboBox/Funcao';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import { FuncaoApi } from '@/app/GerAdv_TS/Funcao/Apis/ApiFuncao';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'
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
const [nomeCargos, setNomeCargos] = useState('');
const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncao, setNomeFuncao] = useState('');
const funcaoApi = new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

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

if (getParamFromUrl('funcao') > 0) {
  if (funcionariosData.id === 0 && funcionariosData.funcao == 0) {
    funcaoApi
    .getById(getParamFromUrl('funcao'))
    .then((response) => {
      setNomeFuncao(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    funcionariosData.funcao = getParamFromUrl('funcao');
  }
}

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
const addValorCargo = (e: any) => {
  if (e?.id>0)
    funcionariosData.cargo = e.id;
  };
  const addValorFuncao = (e: any) => {
    if (e?.id>0)
      funcionariosData.funcao = e.id;
    };
    const addValorCidade = (e: any) => {
      if (e?.id>0)
        funcionariosData.cidade = e.id;
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

                <InputInput
                type='email'
                maxLength={255}
                id='emailpro'
                label='EMailPro'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='emailpro'
                value={funcionariosData.emailpro}
                onChange={onChange}
                />


                <CargosComboBox
                name={'cargo'}
                dataForm={funcionariosData}
                value={funcionariosData.cargo}
                setValue={addValorCargo}
                label={'Cargo'}
                />

                <FuncaoComboBox
                name={'funcao'}
                dataForm={funcionariosData}
                value={funcionariosData.funcao}
                setValue={addValorFuncao}
                label={'Função'}
                />
                <InputCheckbox dataForm={funcionariosData} label='Sexo' name='sexo' checked={funcionariosData.sexo} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={20}
                id='registro'
                label='Registro'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='registro'
                value={funcionariosData.registro}
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

                <InputCheckbox dataForm={funcionariosData} label='Tipo' name='tipo' checked={funcionariosData.tipo} onChange={onChange} />
              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={2147483647}
                id='observacao'
                label='Observacao'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='observacao'
                value={funcionariosData.observacao}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={80}
                id='endereco'
                label='Endereco'
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


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fax'
                label='Fax'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='fax'
                value={funcionariosData.fax}
                onChange={onChange}
                />


                <InputInput
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


                <InputInput
                type='email'
                maxLength={60}
                id='email'
                label='EMail'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='email'
                value={funcionariosData.email}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={2048}
                id='periodo_ini'
                label='Periodo_Ini'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='periodo_ini'
                value={funcionariosData.periodo_ini}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='periodo_fim'
                label='Periodo_Fim'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='periodo_fim'
                value={funcionariosData.periodo_fim}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={15}
                id='ctpsnumero'
                label='CTPSNumero'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='ctpsnumero'
                value={funcionariosData.ctpsnumero}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={10}
                id='ctpsserie'
                label='CTPSSerie'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='ctpsserie'
                value={funcionariosData.ctpsserie}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={20}
                id='pis'
                label='PIS'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='pis'
                value={funcionariosData.pis}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='salario'
                label='Salario'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='salario'
                value={funcionariosData.salario}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='ctpsdtemissao'
                label='CTPSDtEmissao'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='ctpsdtemissao'
                value={funcionariosData.ctpsdtemissao}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='dtnasc'
                label='DtNasc'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='dtnasc'
                value={funcionariosData.dtnasc}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='data'
                label='Data'
                dataForm={funcionariosData}
                className='inputIncNome'
                name='data'
                value={funcionariosData.data}
                onChange={onChange}
                />

              </div><div className='grid-container'><InputCheckbox dataForm={funcionariosData} label='LiberaAgenda' name='liberaagenda' checked={funcionariosData.liberaagenda} onChange={onChange} />

              <InputInput
              type='text'
              maxLength={200}
              id='pasta'
              label='Pasta'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='pasta'
              value={funcionariosData.pasta}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={1}
              id='class'
              label='Class'
              dataForm={funcionariosData}
              className='inputIncNome'
              name='class'
              value={funcionariosData.class}
              onChange={onChange}
              />

              <InputCheckbox dataForm={funcionariosData} label='Ani' name='ani' checked={funcionariosData.ani} onChange={onChange} />
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