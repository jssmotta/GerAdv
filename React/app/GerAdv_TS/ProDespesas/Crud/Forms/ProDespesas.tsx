// Tracking: Forms.tsx.txt
'use client';
import { IProDespesas } from '@/app/GerAdv_TS/ProDespesas/Interfaces/interface.ProDespesas';
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
import { ProDespesasApi } from '../../Apis/ApiProDespesas';
import { useValidationsProDespesas } from '../../Hooks/hookProDespesas';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface ProDespesasFormProps {
  prodespesasData: IProDespesas;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProDespesasForm: React.FC<ProDespesasFormProps> = ({
  prodespesasData, 
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
const dadoApi = new ProDespesasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProDespesas();
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('clientes') > 0) {
  if (prodespesasData.id === 0 && prodespesasData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    prodespesasData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (prodespesasData.id === 0 && prodespesasData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    prodespesasData.processo = getParamFromUrl('processos');
  }
}
const addValorCliente = (e: any) => {
  if (e?.id>0)
    prodespesasData.cliente = e.id;
  };
  const addValorProcesso = (e: any) => {
    if (e?.id>0)
      prodespesasData.processo = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de ProDespesas:', error);
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
            target: document.getElementById(`ProDespesasForm-${prodespesasData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar ProDespesas diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = prodespesasData?.id == 0 ? 'Editar ProDespesas' : 'Adicionar Pro Despesas';
      }
    }, [prodespesasData.id]);
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

      <div className={isMobile ? 'form-container form-container-ProDespesas' : 'form-container form-container-ProDespesas'}>

        <form className='formInputCadInc' id={`ProDespesasForm-${prodespesasData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProDespesas' data={prodespesasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProDespesasForm-${prodespesasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <InputInput
              type='text'
              maxLength={2048}
              id='ligacaoid'
              label='LigacaoID'
              dataForm={prodespesasData}
              className='inputIncNome'
              name='ligacaoid'
              value={prodespesasData.ligacaoid}
              onChange={onChange}
              />


              <ClientesComboBox
              name={'cliente'}
              dataForm={prodespesasData}
              value={prodespesasData.cliente}
              setValue={addValorCliente}
              label={'Clientes'}
              />
              <InputCheckbox dataForm={prodespesasData} label='Corrigido' name='corrigido' checked={prodespesasData.corrigido} onChange={onChange} />

              <InputInput
              type='text'
              maxLength={2048}
              id='data'
              label='Data'
              dataForm={prodespesasData}
              className='inputIncNome'
              name='data'
              value={prodespesasData.data}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='valororiginal'
              label='ValorOriginal'
              dataForm={prodespesasData}
              className='inputIncNome'
              name='valororiginal'
              value={prodespesasData.valororiginal}
              onChange={onChange}
              />


              <ProcessosComboBox
              name={'processo'}
              dataForm={prodespesasData}
              value={prodespesasData.processo}
              setValue={addValorProcesso}
              label={'Processos'}
              />

              <InputInput
              type='text'
              maxLength={2048}
              id='quitado'
              label='Quitado'
              dataForm={prodespesasData}
              className='inputIncNome'
              name='quitado'
              value={prodespesasData.quitado}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='datacorrecao'
              label='DataCorrecao'
              dataForm={prodespesasData}
              className='inputIncNome'
              name='datacorrecao'
              value={prodespesasData.datacorrecao}
              onChange={onChange}
              />


              <InputInput
              type='text'
              maxLength={2048}
              id='valor'
              label='Valor'
              dataForm={prodespesasData}
              className='inputIncNome'
              name='valor'
              value={prodespesasData.valor}
              onChange={onChange}
              />

            </div><div className='grid-container'><InputCheckbox dataForm={prodespesasData} label='Tipo' name='tipo' checked={prodespesasData.tipo} onChange={onChange} />

            <InputInput
            type='text'
            maxLength={100}
            id='historico'
            label='Historico'
            dataForm={prodespesasData}
            className='inputIncNome'
            name='historico'
            value={prodespesasData.historico}
            onChange={onChange}
            />

            <InputCheckbox dataForm={prodespesasData} label='LivroCaixa' name='livrocaixa' checked={prodespesasData.livrocaixa} onChange={onChange} />
          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProDespesas' data={prodespesasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProDespesasForm-${prodespesasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/prodespesas'} id={prodespesasData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };