// Tracking: Forms.tsx.txt
'use client';
import { IStatusBiu } from '@/app/GerAdv_TS/StatusBiu/Interfaces/interface.StatusBiu';
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
import { StatusBiuApi } from '../../Apis/ApiStatusBiu';
import { useValidationsStatusBiu } from '../../Hooks/hookStatusBiu';
import TipoStatusBiuComboBox from '@/app/GerAdv_TS/TipoStatusBiu/ComboBox/TipoStatusBiu';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { TipoStatusBiuApi } from '@/app/GerAdv_TS/TipoStatusBiu/Apis/ApiTipoStatusBiu';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface StatusBiuFormProps {
  statusbiuData: IStatusBiu;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const StatusBiuForm: React.FC<StatusBiuFormProps> = ({
  statusbiuData, 
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
const dadoApi = new StatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsStatusBiu();
const [nomeTipoStatusBiu, setNomeTipoStatusBiu] = useState('');
const tipostatusbiuApi = new TipoStatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('tipostatusbiu') > 0) {
  if (statusbiuData.id === 0 && statusbiuData.tipostatusbiu == 0) {
    tipostatusbiuApi
    .getById(getParamFromUrl('tipostatusbiu'))
    .then((response) => {
      setNomeTipoStatusBiu(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    statusbiuData.tipostatusbiu = getParamFromUrl('tipostatusbiu');
  }
}

if (getParamFromUrl('operador') > 0) {
  if (statusbiuData.id === 0 && statusbiuData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    statusbiuData.operador = getParamFromUrl('operador');
  }
}
const addValorTipoStatusBiu = (e: any) => {
  if (e?.id>0)
    statusbiuData.tipostatusbiu = e.id;
  };
  const addValorOperador = (e: any) => {
    if (e?.id>0)
      statusbiuData.operador = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de StatusBiu:', error);
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
            target: document.getElementById(`StatusBiuForm-${statusbiuData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar StatusBiu diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = statusbiuData?.id == 0 ? 'Editar StatusBiu' : 'Adicionar Status Biu';
      }
    }, [statusbiuData.id]);
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

      <div className={isMobile ? 'form-container form-container-StatusBiu' : 'form-container5 form-container-StatusBiu'}>

        <form className='formInputCadInc' id={`StatusBiuForm-${statusbiuData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='StatusBiu' data={statusbiuData} isSubmitting={isSubmitting} onClose={onClose} formId={`StatusBiuForm-${statusbiuData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputName
              type='text'
              id='nome'
              label='Nome'
              dataForm={statusbiuData}
              className='inputIncNome'
              name='nome'
              value={statusbiuData.nome}
              placeholder={`Informe Nome`}
              onChange={onChange}
              required
              />

              <TipoStatusBiuComboBox
              name={'tipostatusbiu'}
              dataForm={statusbiuData}
              value={statusbiuData.tipostatusbiu}
              setValue={addValorTipoStatusBiu}
              label={'Staus  Usuários'}
              />

              <OperadorComboBox
              name={'operador'}
              dataForm={statusbiuData}
              value={statusbiuData.operador}
              setValue={addValorOperador}
              label={'Operador'}
              />

              <InputInput
              type='text'
              maxLength={2048}
              id='icone'
              label='Icone'
              dataForm={statusbiuData}
              className='inputIncNome'
              name='icone'
              value={statusbiuData.icone}
              onChange={onChange}
              />

            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='StatusBiu' data={statusbiuData} isSubmitting={isSubmitting} onClose={onClose} formId={`StatusBiuForm-${statusbiuData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/statusbiu'} id={statusbiuData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };