// Tracking: Forms.tsx.txt
'use client';
import { IProDepositos } from '@/app/GerAdv_TS/ProDepositos/Interfaces/interface.ProDepositos';
import { useRouter } from 'next/navigation';
import React, { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { ProDepositosApi } from '../../Apis/ApiProDepositos';
import { useValidationsProDepositos } from '../../Hooks/hookProDepositos';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import FaseComboBox from '@/app/GerAdv_TS/Fase/ComboBox/Fase';
import TipoProDespositoComboBox from '@/app/GerAdv_TS/TipoProDesposito/ComboBox/TipoProDesposito';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { FaseApi } from '@/app/GerAdv_TS/Fase/Apis/ApiFase';
import { TipoProDespositoApi } from '@/app/GerAdv_TS/TipoProDesposito/Apis/ApiTipoProDesposito';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ProDepositosFormProps {
  prodepositosData: IProDepositos;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProDepositosForm: React.FC<ProDepositosFormProps> = ({
  prodepositosData, 
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
const dadoApi = new ProDepositosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProDepositos();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFase, setNomeFase] = useState('');
const faseApi = new FaseApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoProDesposito, setNomeTipoProDesposito] = useState('');
const tipoprodespositoApi = new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (prodepositosData.id === 0 && prodepositosData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    prodepositosData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('fase') > 0) {
  if (prodepositosData.id === 0 && prodepositosData.fase == 0) {
    faseApi
    .getById(getParamFromUrl('fase'))
    .then((response) => {
      setNomeFase(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    prodepositosData.fase = getParamFromUrl('fase');
  }
}

if (getParamFromUrl('tipoprodesposito') > 0) {
  if (prodepositosData.id === 0 && prodepositosData.tipoprodesposito == 0) {
    tipoprodespositoApi
    .getById(getParamFromUrl('tipoprodesposito'))
    .then((response) => {
      setNomeTipoProDesposito(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    prodepositosData.tipoprodesposito = getParamFromUrl('tipoprodesposito');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    prodepositosData.processo = e.id;
  };
  const addValorFase = (e: any) => {
    if (e?.id>0)
      prodepositosData.fase = e.id;
    };
    const addValorTipoProDesposito = (e: any) => {
      if (e?.id>0)
        prodepositosData.tipoprodesposito = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de ProDepositos:', error);
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
              target: document.getElementById(`ProDepositosForm-${prodepositosData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar ProDepositos diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = prodepositosData?.id == 0 ? 'Editar ProDepositos' : 'Adicionar Pro Depositos';
        }
      }, [prodepositosData.id]);
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

        <div className={isMobile ? 'form-container form-container-ProDepositos' : 'form-container5 form-container-ProDepositos'}>

          <form className='formInputCadInc' id={`ProDepositosForm-${prodepositosData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProDepositos' data={prodepositosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProDepositosForm-${prodepositosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>


                <ProcessosComboBox
                name={'processo'}
                dataForm={prodepositosData}
                value={prodepositosData.processo}
                setValue={addValorProcesso}
                label={'Processos'}
                />

                <FaseComboBox
                name={'fase'}
                dataForm={prodepositosData}
                value={prodepositosData.fase}
                setValue={addValorFase}
                label={'Fase'}
                />

                <InputInput
                type='text'
                maxLength={2048}
                id='data'
                label='Data'
                dataForm={prodepositosData}
                className='inputIncNome'
                name='data'
                value={prodepositosData.data}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='valor'
                label='Valor'
                dataForm={prodepositosData}
                className='inputIncNome'
                name='valor'
                value={prodepositosData.valor}
                onChange={onChange}
                />


                <TipoProDespositoComboBox
                name={'tipoprodesposito'}
                dataForm={prodepositosData}
                value={prodepositosData.tipoprodesposito}
                setValue={addValorTipoProDesposito}
                label={'Tipo Pro Desposito'}
                />
              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProDepositos' data={prodepositosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProDepositosForm-${prodepositosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/prodepositos'} id={prodepositosData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };