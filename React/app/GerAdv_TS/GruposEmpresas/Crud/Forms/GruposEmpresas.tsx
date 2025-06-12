// Tracking: Forms.tsx.txt
'use client';
import { IGruposEmpresas } from '@/app/GerAdv_TS/GruposEmpresas/Interfaces/interface.GruposEmpresas';
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
import { GruposEmpresasApi } from '../../Apis/ApiGruposEmpresas';
import { useValidationsGruposEmpresas } from '../../Hooks/hookGruposEmpresas';
import OponentesComboBox from '@/app/GerAdv_TS/Oponentes/ComboBox/Oponentes';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { OponentesApi } from '@/app/GerAdv_TS/Oponentes/Apis/ApiOponentes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputDescription from '@/app/components/Inputs/InputDescription';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface GruposEmpresasFormProps {
  gruposempresasData: IGruposEmpresas;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const GruposEmpresasForm: React.FC<GruposEmpresasFormProps> = ({
  gruposempresasData, 
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
const dadoApi = new GruposEmpresasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsGruposEmpresas();
const [nomeOponentes, setNomeOponentes] = useState('');
const oponentesApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('oponentes') > 0) {
  if (gruposempresasData.id === 0 && gruposempresasData.oponente == 0) {
    oponentesApi
    .getById(getParamFromUrl('oponentes'))
    .then((response) => {
      setNomeOponentes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    gruposempresasData.oponente = getParamFromUrl('oponentes');
  }
}

if (getParamFromUrl('clientes') > 0) {
  if (gruposempresasData.id === 0 && gruposempresasData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    gruposempresasData.cliente = getParamFromUrl('clientes');
  }
}
const addValorOponente = (e: any) => {
  if (e?.id>0)
    gruposempresasData.oponente = e.id;
  };
  const addValorCliente = (e: any) => {
    if (e?.id>0)
      gruposempresasData.cliente = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de GruposEmpresas:', error);
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
            target: document.getElementById(`GruposEmpresasForm-${gruposempresasData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar GruposEmpresas diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = gruposempresasData?.id == 0 ? 'Editar GruposEmpresas' : 'Adicionar Grupos Empresas';
      }
    }, [gruposempresasData.id]);
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

      <div className={isMobile ? 'form-container form-container-GruposEmpresas' : 'form-container5 form-container-GruposEmpresas'}>

        <form className='formInputCadInc' id={`GruposEmpresasForm-${gruposempresasData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='GruposEmpresas' data={gruposempresasData} isSubmitting={isSubmitting} onClose={onClose} formId={`GruposEmpresasForm-${gruposempresasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputDescription
              type='text'
              id='descricao'
              label='grupos empresas'
              dataForm={gruposempresasData}
              className='inputIncNome'
              name='descricao'
              value={gruposempresasData.descricao}
              placeholder={`Digite nome grupos empresas`}
              onChange={onChange}
              required
              disabled={gruposempresasData.id > 0}
              />

              <InputInput
              type='email'
              maxLength={255}
              id='email'
              label='EMail'
              dataForm={gruposempresasData}
              className='inputIncNome'
              name='email'
              value={gruposempresasData.email}
              onChange={onChange}
              />

              <InputCheckbox dataForm={gruposempresasData} label='Inativo' name='inativo' checked={gruposempresasData.inativo} onChange={onChange} />

              <OponentesComboBox
              name={'oponente'}
              dataForm={gruposempresasData}
              value={gruposempresasData.oponente}
              setValue={addValorOponente}
              label={'Oponentes'}
              />

              <InputInput
              type='text'
              maxLength={2147483647}
              id='observacoes'
              label='Observacoes'
              dataForm={gruposempresasData}
              className='inputIncNome'
              name='observacoes'
              value={gruposempresasData.observacoes}
              onChange={onChange}
              />


              <ClientesComboBox
              name={'cliente'}
              dataForm={gruposempresasData}
              value={gruposempresasData.cliente}
              setValue={addValorCliente}
              label={'Clientes'}
              />

              <InputInput
              type='text'
              maxLength={255}
              id='icone'
              label='Icone'
              dataForm={gruposempresasData}
              className='inputIncNome'
              name='icone'
              value={gruposempresasData.icone}
              onChange={onChange}
              />

              <InputCheckbox dataForm={gruposempresasData} label='DespesaUnificada' name='despesaunificada' checked={gruposempresasData.despesaunificada} onChange={onChange} />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='GruposEmpresas' data={gruposempresasData} isSubmitting={isSubmitting} onClose={onClose} formId={`GruposEmpresasForm-${gruposempresasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/gruposempresas'} id={gruposempresasData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };