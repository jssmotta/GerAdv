// Tracking: Forms.tsx.txt
'use client';
import { IHonorariosDadosContrato } from '@/app/GerAdv_TS/HonorariosDadosContrato/Interfaces/interface.HonorariosDadosContrato';
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
import { HonorariosDadosContratoApi } from '../../Apis/ApiHonorariosDadosContrato';
import { useValidationsHonorariosDadosContrato } from '../../Hooks/hookHonorariosDadosContrato';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputInput from '@/app/components/Inputs/InputInput'
interface HonorariosDadosContratoFormProps {
  honorariosdadoscontratoData: IHonorariosDadosContrato;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const HonorariosDadosContratoForm: React.FC<HonorariosDadosContratoFormProps> = ({
  honorariosdadoscontratoData, 
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
const dadoApi = new HonorariosDadosContratoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsHonorariosDadosContrato();
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('clientes') > 0) {
  if (honorariosdadoscontratoData.id === 0 && honorariosdadoscontratoData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    honorariosdadoscontratoData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (honorariosdadoscontratoData.id === 0 && honorariosdadoscontratoData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    honorariosdadoscontratoData.processo = getParamFromUrl('processos');
  }
}
const addValorCliente = (e: any) => {
  if (e?.id>0)
    honorariosdadoscontratoData.cliente = e.id;
  };
  const addValorProcesso = (e: any) => {
    if (e?.id>0)
      honorariosdadoscontratoData.processo = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de HonorariosDadosContrato:', error);
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
            target: document.getElementById(`HonorariosDadosContratoForm-${honorariosdadoscontratoData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar HonorariosDadosContrato diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = honorariosdadoscontratoData?.id == 0 ? 'Editar HonorariosDadosContrato' : 'Adicionar Honorarios Dados Contrato';
      }
    }, [honorariosdadoscontratoData.id]);
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

      <div className={isMobile ? 'form-container form-container-HonorariosDadosContrato' : 'form-container5 form-container-HonorariosDadosContrato'}>

        <form className='formInputCadInc' id={`HonorariosDadosContratoForm-${honorariosdadoscontratoData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='HonorariosDadosContrato' data={honorariosdadoscontratoData} isSubmitting={isSubmitting} onClose={onClose} formId={`HonorariosDadosContratoForm-${honorariosdadoscontratoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <ClientesComboBox
              name={'cliente'}
              dataForm={honorariosdadoscontratoData}
              value={honorariosdadoscontratoData.cliente}
              setValue={addValorCliente}
              label={'Clientes'}
              />
              <InputCheckbox dataForm={honorariosdadoscontratoData} label='Fixo' name='fixo' checked={honorariosdadoscontratoData.fixo} onChange={onChange} />
              <InputCheckbox dataForm={honorariosdadoscontratoData} label='Variavel' name='variavel' checked={honorariosdadoscontratoData.variavel} onChange={onChange} />

              <InputInput
              type='text'
              maxLength={2048}
              id='percsucesso'
              label='PercSucesso'
              dataForm={honorariosdadoscontratoData}
              className='inputIncNome'
              name='percsucesso'
              value={honorariosdadoscontratoData.percsucesso}
              onChange={onChange}
              />


              <ProcessosComboBox
              name={'processo'}
              dataForm={honorariosdadoscontratoData}
              value={honorariosdadoscontratoData.processo}
              setValue={addValorProcesso}
              label={'Processos'}
              />

              <InputInput
              type='text'
              maxLength={2048}
              id='arquivocontrato'
              label='ArquivoContrato'
              dataForm={honorariosdadoscontratoData}
              className='inputIncNome'
              name='arquivocontrato'
              value={honorariosdadoscontratoData.arquivocontrato}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2147483647}
              id='textocontrato'
              label='TextoContrato'
              dataForm={honorariosdadoscontratoData}
              className='inputIncNome'
              name='textocontrato'
              value={honorariosdadoscontratoData.textocontrato}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='valorfixo'
              label='ValorFixo'
              dataForm={honorariosdadoscontratoData}
              className='inputIncNome'
              name='valorfixo'
              value={honorariosdadoscontratoData.valorfixo}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='observacao'
              label='Observacao'
              dataForm={honorariosdadoscontratoData}
              className='inputIncNome'
              name='observacao'
              value={honorariosdadoscontratoData.observacao}
              onChange={onChange}
              />

            </div><div className='grid-container'>
              <InputInput
              type='text'
              maxLength={2048}
              id='datacontrato'
              label='DataContrato'
              dataForm={honorariosdadoscontratoData}
              className='inputIncNome'
              name='datacontrato'
              value={honorariosdadoscontratoData.datacontrato}
              onChange={onChange}
              />

            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='HonorariosDadosContrato' data={honorariosdadoscontratoData} isSubmitting={isSubmitting} onClose={onClose} formId={`HonorariosDadosContratoForm-${honorariosdadoscontratoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/honorariosdadoscontrato'} id={honorariosdadoscontratoData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };