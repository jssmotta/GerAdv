// Tracking: Forms.tsx.txt
'use client';
import { IPrepostos } from '@/app/GerAdv_TS/Prepostos/Interfaces/interface.Prepostos';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { PrepostosApi } from '../../Apis/ApiPrepostos';
import { useValidationsPrepostos } from '../../Hooks/hookPrepostos';
import FuncaoComboBox from '@/app/GerAdv_TS/Funcao/ComboBox/Funcao';
import SetorComboBox from '@/app/GerAdv_TS/Setor/ComboBox/Setor';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { FuncaoApi } from '@/app/GerAdv_TS/Funcao/Apis/ApiFuncao';
import { SetorApi } from '@/app/GerAdv_TS/Setor/Apis/ApiSetor';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCep from '@/app/components/Inputs/InputCep'
interface PrepostosFormProps {
  prepostosData: IPrepostos;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const PrepostosForm: React.FC<PrepostosFormProps> = ({
  prepostosData, 
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
const dadoApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsPrepostos();
const [nomeFuncao, setNomeFuncao] = useState('');
const funcaoApi = new FuncaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeSetor, setNomeSetor] = useState('');
const setorApi = new SetorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('funcao') > 0) {
  if (prepostosData.id === 0 && prepostosData.funcao == 0) {
    funcaoApi
    .getById(getParamFromUrl('funcao'))
    .then((response) => {
      setNomeFuncao(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    prepostosData.funcao = getParamFromUrl('funcao');
  }
}

if (getParamFromUrl('setor') > 0) {
  if (prepostosData.id === 0 && prepostosData.setor == 0) {
    setorApi
    .getById(getParamFromUrl('setor'))
    .then((response) => {
      setNomeSetor(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    prepostosData.setor = getParamFromUrl('setor');
  }
}

if (getParamFromUrl('cidade') > 0) {
  if (prepostosData.id === 0 && prepostosData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    prepostosData.cidade = getParamFromUrl('cidade');
  }
}
const addValorFuncao = (e: any) => {
  if (e?.id>0)
    prepostosData.funcao = e.id;
  };
  const addValorSetor = (e: any) => {
    if (e?.id>0)
      prepostosData.setor = e.id;
    };
    const addValorCidade = (e: any) => {
      if (e?.id>0)
        prepostosData.cidade = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de Prepostos:', error);
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
              target: document.getElementById(`PrepostosForm-${prepostosData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar Prepostos diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = prepostosData?.id == 0 ? 'Editar Prepostos' : 'Adicionar Prepostos';
        }
      }, [prepostosData.id]);
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

        <div className={isMobile ? 'form-container form-container-Prepostos' : 'form-container form-container-Prepostos'}>

          <form className='formInputCadInc' id={`PrepostosForm-${prepostosData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Prepostos' data={prepostosData} isSubmitting={isSubmitting} onClose={onClose} formId={`PrepostosForm-${prepostosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>

                <InputName
                type='text'
                id='nome'
                label='Nome'
                dataForm={prepostosData}
                className='inputIncNome'
                name='nome'
                value={prepostosData.nome}
                placeholder={`Informe Nome`}
                onChange={onChange}
                required
                />

                <FuncaoComboBox
                name={'funcao'}
                dataForm={prepostosData}
                value={prepostosData.funcao}
                setValue={addValorFuncao}
                label={'Função'}
                />

                <SetorComboBox
                name={'setor'}
                dataForm={prepostosData}
                value={prepostosData.setor}
                setValue={addValorSetor}
                label={'Setor'}
                />

                <InputInput
                type='text'
                maxLength={2048}
                id='dtnasc'
                label='DtNasc'
                dataForm={prepostosData}
                className='inputIncNome'
                name='dtnasc'
                value={prepostosData.dtnasc}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={100}
                id='qualificacao'
                label='Qualificacao'
                dataForm={prepostosData}
                className='inputIncNome'
                name='qualificacao'
                value={prepostosData.qualificacao}
                onChange={onChange}
                />

                <InputCheckbox dataForm={prepostosData} label='Sexo' name='sexo' checked={prepostosData.sexo} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={2048}
                id='idade'
                label='Idade'
                dataForm={prepostosData}
                className='inputIncNome'
                name='idade'
                value={prepostosData.idade}
                onChange={onChange}
                />


                <InputCpf
                type='text'
                id='cpf'
                label='CPF'
                dataForm={prepostosData}
                className='inputIncNome'
                name='cpf'
                value={prepostosData.cpf}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={30}
                id='rg'
                label='RG'
                dataForm={prepostosData}
                className='inputIncNome'
                name='rg'
                value={prepostosData.rg}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='periodo_ini'
                label='Periodo_Ini'
                dataForm={prepostosData}
                className='inputIncNome'
                name='periodo_ini'
                value={prepostosData.periodo_ini}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={2048}
                id='periodo_fim'
                label='Periodo_Fim'
                dataForm={prepostosData}
                className='inputIncNome'
                name='periodo_fim'
                value={prepostosData.periodo_fim}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={30}
                id='registro'
                label='Registro'
                dataForm={prepostosData}
                className='inputIncNome'
                name='registro'
                value={prepostosData.registro}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={15}
                id='ctpsnumero'
                label='CTPSNumero'
                dataForm={prepostosData}
                className='inputIncNome'
                name='ctpsnumero'
                value={prepostosData.ctpsnumero}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={10}
                id='ctpsserie'
                label='CTPSSerie'
                dataForm={prepostosData}
                className='inputIncNome'
                name='ctpsserie'
                value={prepostosData.ctpsserie}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='ctpsdtemissao'
                label='CTPSDtEmissao'
                dataForm={prepostosData}
                className='inputIncNome'
                name='ctpsdtemissao'
                value={prepostosData.ctpsdtemissao}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={20}
                id='pis'
                label='PIS'
                dataForm={prepostosData}
                className='inputIncNome'
                name='pis'
                value={prepostosData.pis}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='salario'
                label='Salario'
                dataForm={prepostosData}
                className='inputIncNome'
                name='salario'
                value={prepostosData.salario}
                onChange={onChange}
                />

                <InputCheckbox dataForm={prepostosData} label='LiberaAgenda' name='liberaagenda' checked={prepostosData.liberaagenda} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={2147483647}
                id='observacao'
                label='Observacao'
                dataForm={prepostosData}
                className='inputIncNome'
                name='observacao'
                value={prepostosData.observacao}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={80}
                id='endereco'
                label='Endereco'
                dataForm={prepostosData}
                className='inputIncNome'
                name='endereco'
                value={prepostosData.endereco}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={50}
                id='bairro'
                label='Bairro'
                dataForm={prepostosData}
                className='inputIncNome'
                name='bairro'
                value={prepostosData.bairro}
                onChange={onChange}
                />


                <CidadeComboBox
                name={'cidade'}
                dataForm={prepostosData}
                value={prepostosData.cidade}
                setValue={addValorCidade}
                label={'Cidade'}
                />

                <InputCep
                type='text'
                id='cep'
                label='CEP'
                dataForm={prepostosData}
                className='inputIncNome'
                name='cep'
                value={prepostosData.cep}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fone'
                label='Fone'
                dataForm={prepostosData}
                className='inputIncNome'
                name='fone'
                value={prepostosData.fone}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fax'
                label='Fax'
                dataForm={prepostosData}
                className='inputIncNome'
                name='fax'
                value={prepostosData.fax}
                onChange={onChange}
                />


                <InputInput
                type='email'
                maxLength={255}
                id='email'
                label='EMail'
                dataForm={prepostosData}
                className='inputIncNome'
                name='email'
                value={prepostosData.email}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={50}
                id='pai'
                label='Pai'
                dataForm={prepostosData}
                className='inputIncNome'
                name='pai'
                value={prepostosData.pai}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={50}
                id='mae'
                label='Mae'
                dataForm={prepostosData}
                className='inputIncNome'
                name='mae'
                value={prepostosData.mae}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={1}
                id='class'
                label='Class'
                dataForm={prepostosData}
                className='inputIncNome'
                name='class'
                value={prepostosData.class}
                onChange={onChange}
                />

                <InputCheckbox dataForm={prepostosData} label='Ani' name='ani' checked={prepostosData.ani} onChange={onChange} />
              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Prepostos' data={prepostosData} isSubmitting={isSubmitting} onClose={onClose} formId={`PrepostosForm-${prepostosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/prepostos'} id={prepostosData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };