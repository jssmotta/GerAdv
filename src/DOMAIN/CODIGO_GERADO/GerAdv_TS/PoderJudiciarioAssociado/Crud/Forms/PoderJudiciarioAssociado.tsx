// Tracking: Forms.tsx.txt
'use client';
import { IPoderJudiciarioAssociado } from '@/app/GerAdv_TS/PoderJudiciarioAssociado/Interfaces/interface.PoderJudiciarioAssociado';
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
import { PoderJudiciarioAssociadoApi } from '../../Apis/ApiPoderJudiciarioAssociado';
import { useValidationsPoderJudiciarioAssociado } from '../../Hooks/hookPoderJudiciarioAssociado';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import TribunalComboBox from '@/app/GerAdv_TS/Tribunal/ComboBox/Tribunal';
import ForoComboBox from '@/app/GerAdv_TS/Foro/ComboBox/Foro';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { TribunalApi } from '@/app/GerAdv_TS/Tribunal/Apis/ApiTribunal';
import { ForoApi } from '@/app/GerAdv_TS/Foro/Apis/ApiForo';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface PoderJudiciarioAssociadoFormProps {
  poderjudiciarioassociadoData: IPoderJudiciarioAssociado;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const PoderJudiciarioAssociadoForm: React.FC<PoderJudiciarioAssociadoFormProps> = ({
  poderjudiciarioassociadoData, 
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
const dadoApi = new PoderJudiciarioAssociadoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsPoderJudiciarioAssociado();
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTribunal, setNomeTribunal] = useState('');
const tribunalApi = new TribunalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeForo, setNomeForo] = useState('');
const foroApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('justica') > 0) {
  if (poderjudiciarioassociadoData.id === 0 && poderjudiciarioassociadoData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    poderjudiciarioassociadoData.justica = getParamFromUrl('justica');
  }
}

if (getParamFromUrl('area') > 0) {
  if (poderjudiciarioassociadoData.id === 0 && poderjudiciarioassociadoData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    poderjudiciarioassociadoData.area = getParamFromUrl('area');
  }
}

if (getParamFromUrl('tribunal') > 0) {
  if (poderjudiciarioassociadoData.id === 0 && poderjudiciarioassociadoData.tribunal == 0) {
    tribunalApi
    .getById(getParamFromUrl('tribunal'))
    .then((response) => {
      setNomeTribunal(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    poderjudiciarioassociadoData.tribunal = getParamFromUrl('tribunal');
  }
}

if (getParamFromUrl('foro') > 0) {
  if (poderjudiciarioassociadoData.id === 0 && poderjudiciarioassociadoData.foro == 0) {
    foroApi
    .getById(getParamFromUrl('foro'))
    .then((response) => {
      setNomeForo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    poderjudiciarioassociadoData.foro = getParamFromUrl('foro');
  }
}

if (getParamFromUrl('cidade') > 0) {
  if (poderjudiciarioassociadoData.id === 0 && poderjudiciarioassociadoData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    poderjudiciarioassociadoData.cidade = getParamFromUrl('cidade');
  }
}
const addValorJustica = (e: any) => {
  if (e?.id>0)
    poderjudiciarioassociadoData.justica = e.id;
  };
  const addValorArea = (e: any) => {
    if (e?.id>0)
      poderjudiciarioassociadoData.area = e.id;
    };
    const addValorTribunal = (e: any) => {
      if (e?.id>0)
        poderjudiciarioassociadoData.tribunal = e.id;
      };
      const addValorForo = (e: any) => {
        if (e?.id>0)
          poderjudiciarioassociadoData.foro = e.id;
        };
        const addValorCidade = (e: any) => {
          if (e?.id>0)
            poderjudiciarioassociadoData.cidade = e.id;
          };
          const onConfirm = (e: React.FormEvent) => {
            e.preventDefault();
            if (e.stopPropagation) e.stopPropagation();

              if (!isSubmitting) {
                setIsSubmitting(true);

                try {
                  onSubmit(e);
                } catch (error) {
                console.error('Erro ao submeter formulário de PoderJudiciarioAssociado:', error);
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
                  target: document.getElementById(`PoderJudiciarioAssociadoForm-${poderjudiciarioassociadoData.id}`)
                } as unknown as React.FormEvent;

                onSubmit(syntheticEvent);
              } catch (error) {
              console.error('Erro ao salvar PoderJudiciarioAssociado diretamente:', error);
              setIsSubmitting(false);
              if (onError) onError();
              }
            }
          };
          useEffect(() => {
            const el = document.querySelector('.nameFormMobile');
            if (el) {
              el.textContent = poderjudiciarioassociadoData?.id == 0 ? 'Editar PoderJudiciarioAssociado' : 'Adicionar Poder Judiciario Associado';
            }
          }, [poderjudiciarioassociadoData.id]);
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

            <div className={isMobile ? 'form-container form-container-PoderJudiciarioAssociado' : 'form-container form-container-PoderJudiciarioAssociado'}>

              <form className='formInputCadInc' id={`PoderJudiciarioAssociadoForm-${poderjudiciarioassociadoData.id}`} onSubmit={onConfirm}>
                {!isMobile && (
                  <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='PoderJudiciarioAssociado' data={poderjudiciarioassociadoData} isSubmitting={isSubmitting} onClose={onClose} formId={`PoderJudiciarioAssociadoForm-${poderjudiciarioassociadoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                  )}
                  <div className='grid-container'>


                    <JusticaComboBox
                    name={'justica'}
                    dataForm={poderjudiciarioassociadoData}
                    value={poderjudiciarioassociadoData.justica}
                    setValue={addValorJustica}
                    label={'Justiça'}
                    />

                    <InputInput
                    type='text'
                    maxLength={255}
                    id='justicanome'
                    label='JusticaNome'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='justicanome'
                    value={poderjudiciarioassociadoData.justicanome}
                    onChange={onChange}
                    />


                    <AreaComboBox
                    name={'area'}
                    dataForm={poderjudiciarioassociadoData}
                    value={poderjudiciarioassociadoData.area}
                    setValue={addValorArea}
                    label={'Área'}
                    />

                    <InputInput
                    type='text'
                    maxLength={255}
                    id='areanome'
                    label='AreaNome'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='areanome'
                    value={poderjudiciarioassociadoData.areanome}
                    onChange={onChange}
                    />


                    <TribunalComboBox
                    name={'tribunal'}
                    dataForm={poderjudiciarioassociadoData}
                    value={poderjudiciarioassociadoData.tribunal}
                    setValue={addValorTribunal}
                    label={'Tribunal'}
                    />

                    <InputInput
                    type='text'
                    maxLength={255}
                    id='tribunalnome'
                    label='TribunalNome'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='tribunalnome'
                    value={poderjudiciarioassociadoData.tribunalnome}
                    onChange={onChange}
                    />


                    <ForoComboBox
                    name={'foro'}
                    dataForm={poderjudiciarioassociadoData}
                    value={poderjudiciarioassociadoData.foro}
                    setValue={addValorForo}
                    label={'Foro'}
                    />

                    <InputInput
                    type='text'
                    maxLength={255}
                    id='foronome'
                    label='ForoNome'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='foronome'
                    value={poderjudiciarioassociadoData.foronome}
                    onChange={onChange}
                    />

                  </div><div className='grid-container'>
                    <CidadeComboBox
                    name={'cidade'}
                    dataForm={poderjudiciarioassociadoData}
                    value={poderjudiciarioassociadoData.cidade}
                    setValue={addValorCidade}
                    label={'Cidade'}
                    />

                    <InputInput
                    type='text'
                    maxLength={255}
                    id='subdivisaonome'
                    label='SubDivisaoNome'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='subdivisaonome'
                    value={poderjudiciarioassociadoData.subdivisaonome}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={255}
                    id='cidadenome'
                    label='CidadeNome'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='cidadenome'
                    value={poderjudiciarioassociadoData.cidadenome}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='subdivisao'
                    label='SubDivisao'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='subdivisao'
                    value={poderjudiciarioassociadoData.subdivisao}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='tipo'
                    label='Tipo'
                    dataForm={poderjudiciarioassociadoData}
                    className='inputIncNome'
                    name='tipo'
                    value={poderjudiciarioassociadoData.tipo}
                    onChange={onChange}
                    />

                  </div>
                </form>


                {isMobile && (
                  <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='PoderJudiciarioAssociado' data={poderjudiciarioassociadoData} isSubmitting={isSubmitting} onClose={onClose} formId={`PoderJudiciarioAssociadoForm-${poderjudiciarioassociadoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                  )}
                  <DeleteButton page={'/pages/poderjudiciarioassociado'} id={poderjudiciarioassociadoData.id} closeModel={onClose} dadoApi={dadoApi} />
                </div>
                <div className='form-spacer'></div>
                </>
              );
            };