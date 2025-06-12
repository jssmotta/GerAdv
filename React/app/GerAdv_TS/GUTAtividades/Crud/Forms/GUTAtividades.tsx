// Tracking: Forms.tsx.txt
'use client';
import { IGUTAtividades } from '@/app/GerAdv_TS/GUTAtividades/Interfaces/interface.GUTAtividades';
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
import { GUTAtividadesApi } from '../../Apis/ApiGUTAtividades';
import { useValidationsGUTAtividades } from '../../Hooks/hookGUTAtividades';
import GUTPeriodicidadeComboBox from '@/app/GerAdv_TS/GUTPeriodicidade/ComboBox/GUTPeriodicidade';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { GUTPeriodicidadeApi } from '@/app/GerAdv_TS/GUTPeriodicidade/Apis/ApiGUTPeriodicidade';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface GUTAtividadesFormProps {
  gutatividadesData: IGUTAtividades;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const GUTAtividadesForm: React.FC<GUTAtividadesFormProps> = ({
  gutatividadesData, 
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
const dadoApi = new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsGUTAtividades();
const [nomeGUTPeriodicidade, setNomeGUTPeriodicidade] = useState('');
const gutperiodicidadeApi = new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('gutperiodicidade') > 0) {
  if (gutatividadesData.id === 0 && gutatividadesData.gutperiodicidade == 0) {
    gutperiodicidadeApi
    .getById(getParamFromUrl('gutperiodicidade'))
    .then((response) => {
      setNomeGUTPeriodicidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    gutatividadesData.gutperiodicidade = getParamFromUrl('gutperiodicidade');
  }
}

if (getParamFromUrl('operador') > 0) {
  if (gutatividadesData.id === 0 && gutatividadesData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    gutatividadesData.operador = getParamFromUrl('operador');
  }
}
const addValorGUTPeriodicidade = (e: any) => {
  if (e?.id>0)
    gutatividadesData.gutperiodicidade = e.id;
  };
  const addValorOperador = (e: any) => {
    if (e?.id>0)
      gutatividadesData.operador = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de GUTAtividades:', error);
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
            target: document.getElementById(`GUTAtividadesForm-${gutatividadesData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar GUTAtividades diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = gutatividadesData?.id == 0 ? 'Editar GUTAtividades' : 'Adicionar G U T Atividades';
      }
    }, [gutatividadesData.id]);
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

      <div className={isMobile ? 'form-container form-container-GUTAtividades' : 'form-container5 form-container-GUTAtividades'}>

        <form className='formInputCadInc' id={`GUTAtividadesForm-${gutatividadesData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='GUTAtividades' data={gutatividadesData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTAtividadesForm-${gutatividadesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputName
              type='text'
              id='nome'
              label='Nome'
              dataForm={gutatividadesData}
              className='inputIncNome'
              name='nome'
              value={gutatividadesData.nome}
              placeholder={`Informe Nome`}
              onChange={onChange}
              required
              />

              <InputInput
              type='text'
              maxLength={2147483647}
              id='observacao'
              label='Observacao'
              dataForm={gutatividadesData}
              className='inputIncNome'
              name='observacao'
              value={gutatividadesData.observacao}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='gutgrupo'
              label='GUTGrupo'
              dataForm={gutatividadesData}
              className='inputIncNome'
              name='gutgrupo'
              value={gutatividadesData.gutgrupo}
              onChange={onChange}
              />


              <GUTPeriodicidadeComboBox
              name={'gutperiodicidade'}
              dataForm={gutatividadesData}
              value={gutatividadesData.gutperiodicidade}
              setValue={addValorGUTPeriodicidade}
              label={'G U T Periodicidade'}
              />

              <OperadorComboBox
              name={'operador'}
              dataForm={gutatividadesData}
              value={gutatividadesData.operador}
              setValue={addValorOperador}
              label={'Operador'}
              />
              <InputCheckbox dataForm={gutatividadesData} label='Concluido' name='concluido' checked={gutatividadesData.concluido} onChange={onChange} />

              <InputInput
              type='text'
              maxLength={2048}
              id='dataconcluido'
              label='DataConcluido'
              dataForm={gutatividadesData}
              className='inputIncNome'
              name='dataconcluido'
              value={gutatividadesData.dataconcluido}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='diasparainiciar'
              label='DiasParaIniciar'
              dataForm={gutatividadesData}
              className='inputIncNome'
              name='diasparainiciar'
              value={gutatividadesData.diasparainiciar}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='minutospararealizar'
              label='MinutosParaRealizar'
              dataForm={gutatividadesData}
              className='inputIncNome'
              name='minutospararealizar'
              value={gutatividadesData.minutospararealizar}
              onChange={onChange}
              />

            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='GUTAtividades' data={gutatividadesData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTAtividadesForm-${gutatividadesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/gutatividades'} id={gutatividadesData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };