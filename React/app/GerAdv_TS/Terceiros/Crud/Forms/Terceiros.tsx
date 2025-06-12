// Tracking: Forms.tsx.txt
'use client';
import { ITerceiros } from '@/app/GerAdv_TS/Terceiros/Interfaces/interface.Terceiros';
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
import { TerceirosApi } from '../../Apis/ApiTerceiros';
import { useValidationsTerceiros } from '../../Hooks/hookTerceiros';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import PosicaoOutrasPartesComboBox from '@/app/GerAdv_TS/PosicaoOutrasPartes/ComboBox/PosicaoOutrasPartes';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { PosicaoOutrasPartesApi } from '@/app/GerAdv_TS/PosicaoOutrasPartes/Apis/ApiPosicaoOutrasPartes';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface TerceirosFormProps {
  terceirosData: ITerceiros;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TerceirosForm: React.FC<TerceirosFormProps> = ({
  terceirosData, 
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
const dadoApi = new TerceirosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTerceiros();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePosicaoOutrasPartes, setNomePosicaoOutrasPartes] = useState('');
const posicaooutraspartesApi = new PosicaoOutrasPartesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (terceirosData.id === 0 && terceirosData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    terceirosData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('posicaooutraspartes') > 0) {
  if (terceirosData.id === 0 && terceirosData.situacao == 0) {
    posicaooutraspartesApi
    .getById(getParamFromUrl('posicaooutraspartes'))
    .then((response) => {
      setNomePosicaoOutrasPartes(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    terceirosData.situacao = getParamFromUrl('posicaooutraspartes');
  }
}

if (getParamFromUrl('cidade') > 0) {
  if (terceirosData.id === 0 && terceirosData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    terceirosData.cidade = getParamFromUrl('cidade');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    terceirosData.processo = e.id;
  };
  const addValorSituacao = (e: any) => {
    if (e?.id>0)
      terceirosData.situacao = e.id;
    };
    const addValorCidade = (e: any) => {
      if (e?.id>0)
        terceirosData.cidade = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de Terceiros:', error);
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
              target: document.getElementById(`TerceirosForm-${terceirosData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar Terceiros diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = terceirosData?.id == 0 ? 'Editar Terceiros' : 'Adicionar Terceiros';
        }
      }, [terceirosData.id]);
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

        <div className={isMobile ? 'form-container form-container-Terceiros' : 'form-container form-container-Terceiros'}>

          <form className='formInputCadInc' id={`TerceirosForm-${terceirosData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Terceiros' data={terceirosData} isSubmitting={isSubmitting} onClose={onClose} formId={`TerceirosForm-${terceirosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>

                <InputName
                type='text'
                id='nome'
                label='Nome'
                dataForm={terceirosData}
                className='inputIncNome'
                name='nome'
                value={terceirosData.nome}
                placeholder={`Informe Nome`}
                onChange={onChange}
                required
                />

                <ProcessosComboBox
                name={'processo'}
                dataForm={terceirosData}
                value={terceirosData.processo}
                setValue={addValorProcesso}
                label={'Processos'}
                />

                <PosicaoOutrasPartesComboBox
                name={'situacao'}
                dataForm={terceirosData}
                value={terceirosData.situacao}
                setValue={addValorSituacao}
                label={'Posicao Outras Partes'}
                />

                <CidadeComboBox
                name={'cidade'}
                dataForm={terceirosData}
                value={terceirosData.cidade}
                setValue={addValorCidade}
                label={'Cidade'}
                />

                <InputInput
                type='text'
                maxLength={80}
                id='endereco'
                label='Endereco'
                dataForm={terceirosData}
                className='inputIncNome'
                name='endereco'
                value={terceirosData.endereco}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={50}
                id='bairro'
                label='Bairro'
                dataForm={terceirosData}
                className='inputIncNome'
                name='bairro'
                value={terceirosData.bairro}
                onChange={onChange}
                />


                <InputCep
                type='text'
                id='cep'
                label='CEP'
                dataForm={terceirosData}
                className='inputIncNome'
                name='cep'
                value={terceirosData.cep}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fone'
                label='Fone'
                dataForm={terceirosData}
                className='inputIncNome'
                name='fone'
                value={terceirosData.fone}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fax'
                label='Fax'
                dataForm={terceirosData}
                className='inputIncNome'
                name='fax'
                value={terceirosData.fax}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='obs'
                label='OBS'
                dataForm={terceirosData}
                className='inputIncNome'
                name='obs'
                value={terceirosData.obs}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='email'
                maxLength={150}
                id='email'
                label='EMail'
                dataForm={terceirosData}
                className='inputIncNome'
                name='email'
                value={terceirosData.email}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={1}
                id='class'
                label='Class'
                dataForm={terceirosData}
                className='inputIncNome'
                name='class'
                value={terceirosData.class}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={255}
                id='varaforocomarca'
                label='VaraForoComarca'
                dataForm={terceirosData}
                className='inputIncNome'
                name='varaforocomarca'
                value={terceirosData.varaforocomarca}
                onChange={onChange}
                />

                <InputCheckbox dataForm={terceirosData} label='Sexo' name='sexo' checked={terceirosData.sexo} onChange={onChange} />
              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Terceiros' data={terceirosData} isSubmitting={isSubmitting} onClose={onClose} formId={`TerceirosForm-${terceirosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/terceiros'} id={terceirosData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };