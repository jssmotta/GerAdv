// Tracking: Forms.tsx.txt
'use client';
import { IInstancia } from '@/app/GerAdv_TS/Instancia/Interfaces/interface.Instancia';
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
import { InstanciaApi } from '../../Apis/ApiInstancia';
import { useValidationsInstancia } from '../../Hooks/hookInstancia';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import AcaoComboBox from '@/app/GerAdv_TS/Acao/ComboBox/Acao';
import ForoComboBox from '@/app/GerAdv_TS/Foro/ComboBox/Foro';
import TipoRecursoComboBox from '@/app/GerAdv_TS/TipoRecurso/ComboBox/TipoRecurso';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { AcaoApi } from '@/app/GerAdv_TS/Acao/Apis/ApiAcao';
import { ForoApi } from '@/app/GerAdv_TS/Foro/Apis/ApiForo';
import { TipoRecursoApi } from '@/app/GerAdv_TS/TipoRecurso/Apis/ApiTipoRecurso';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface InstanciaFormProps {
  instanciaData: IInstancia;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const InstanciaForm: React.FC<InstanciaFormProps> = ({
  instanciaData, 
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
const dadoApi = new InstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsInstancia();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAcao, setNomeAcao] = useState('');
const acaoApi = new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeForo, setNomeForo] = useState('');
const foroApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoRecurso, setNomeTipoRecurso] = useState('');
const tiporecursoApi = new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (instanciaData.id === 0 && instanciaData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    instanciaData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('acao') > 0) {
  if (instanciaData.id === 0 && instanciaData.acao == 0) {
    acaoApi
    .getById(getParamFromUrl('acao'))
    .then((response) => {
      setNomeAcao(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    instanciaData.acao = getParamFromUrl('acao');
  }
}

if (getParamFromUrl('foro') > 0) {
  if (instanciaData.id === 0 && instanciaData.foro == 0) {
    foroApi
    .getById(getParamFromUrl('foro'))
    .then((response) => {
      setNomeForo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    instanciaData.foro = getParamFromUrl('foro');
  }
}

if (getParamFromUrl('tiporecurso') > 0) {
  if (instanciaData.id === 0 && instanciaData.tiporecurso == 0) {
    tiporecursoApi
    .getById(getParamFromUrl('tiporecurso'))
    .then((response) => {
      setNomeTipoRecurso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    instanciaData.tiporecurso = getParamFromUrl('tiporecurso');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    instanciaData.processo = e.id;
  };
  const addValorAcao = (e: any) => {
    if (e?.id>0)
      instanciaData.acao = e.id;
    };
    const addValorForo = (e: any) => {
      if (e?.id>0)
        instanciaData.foro = e.id;
      };
      const addValorTipoRecurso = (e: any) => {
        if (e?.id>0)
          instanciaData.tiporecurso = e.id;
        };
        const onConfirm = (e: React.FormEvent) => {
          e.preventDefault();
          if (e.stopPropagation) e.stopPropagation();

            if (!isSubmitting) {
              setIsSubmitting(true);

              try {
                onSubmit(e);
              } catch (error) {
              console.error('Erro ao submeter formulário de Instancia:', error);
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
                target: document.getElementById(`InstanciaForm-${instanciaData.id}`)
              } as unknown as React.FormEvent;

              onSubmit(syntheticEvent);
            } catch (error) {
            console.error('Erro ao salvar Instancia diretamente:', error);
            setIsSubmitting(false);
            if (onError) onError();
            }
          }
        };
        useEffect(() => {
          const el = document.querySelector('.nameFormMobile');
          if (el) {
            el.textContent = instanciaData?.id == 0 ? 'Editar Instancia' : 'Adicionar Instancia';
          }
        }, [instanciaData.id]);
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

          <div className={isMobile ? 'form-container form-container-Instancia' : 'form-container form-container-Instancia'}>

            <form className='formInputCadInc' id={`InstanciaForm-${instanciaData.id}`} onSubmit={onConfirm}>
              {!isMobile && (
                <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Instancia' data={instanciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`InstanciaForm-${instanciaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                )}
                <div className='grid-container'>

                  <InputName
                  type='text'
                  id='nroprocesso'
                  label='NroProcesso'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='nroprocesso'
                  value={instanciaData.nroprocesso}
                  placeholder={`Informe NroProcesso`}
                  onChange={onChange}
                  required
                  />

                  <InputInput
                  type='text'
                  maxLength={2147483647}
                  id='liminarpedida'
                  label='LiminarPedida'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='liminarpedida'
                  value={instanciaData.liminarpedida}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={255}
                  id='objeto'
                  label='Objeto'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='objeto'
                  value={instanciaData.objeto}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='statusresultado'
                  label='StatusResultado'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='statusresultado'
                  value={instanciaData.statusresultado}
                  onChange={onChange}
                  />

                  <InputCheckbox dataForm={instanciaData} label='LiminarPendente' name='liminarpendente' checked={instanciaData.liminarpendente} onChange={onChange} />
                  <InputCheckbox dataForm={instanciaData} label='InterpusemosRecurso' name='interpusemosrecurso' checked={instanciaData.interpusemosrecurso} onChange={onChange} />
                  <InputCheckbox dataForm={instanciaData} label='LiminarConcedida' name='liminarconcedida' checked={instanciaData.liminarconcedida} onChange={onChange} />
                  <InputCheckbox dataForm={instanciaData} label='LiminarNegada' name='liminarnegada' checked={instanciaData.liminarnegada} onChange={onChange} />

                  <ProcessosComboBox
                  name={'processo'}
                  dataForm={instanciaData}
                  value={instanciaData.processo}
                  setValue={addValorProcesso}
                  label={'Processos'}
                  />
                </div><div className='grid-container'>
                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='data'
                  label='Data'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='data'
                  value={instanciaData.data}
                  onChange={onChange}
                  />

                  <InputCheckbox dataForm={instanciaData} label='LiminarParcial' name='liminarparcial' checked={instanciaData.liminarparcial} onChange={onChange} />

                  <InputInput
                  type='text'
                  maxLength={2147483647}
                  id='liminarresultado'
                  label='LiminarResultado'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='liminarresultado'
                  value={instanciaData.liminarresultado}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='divisao'
                  label='Divisao'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='divisao'
                  value={instanciaData.divisao}
                  onChange={onChange}
                  />

                  <InputCheckbox dataForm={instanciaData} label='LiminarCliente' name='liminarcliente' checked={instanciaData.liminarcliente} onChange={onChange} />

                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='comarca'
                  label='Comarca'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='comarca'
                  value={instanciaData.comarca}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='subdivisao'
                  label='SubDivisao'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='subdivisao'
                  value={instanciaData.subdivisao}
                  onChange={onChange}
                  />

                  <InputCheckbox dataForm={instanciaData} label='Principal' name='principal' checked={instanciaData.principal} onChange={onChange} />

                  <AcaoComboBox
                  name={'acao'}
                  dataForm={instanciaData}
                  value={instanciaData.acao}
                  setValue={addValorAcao}
                  label={'Acao'}
                  />
                </div><div className='grid-container'>
                  <ForoComboBox
                  name={'foro'}
                  dataForm={instanciaData}
                  value={instanciaData.foro}
                  setValue={addValorForo}
                  label={'Foro'}
                  />

                  <TipoRecursoComboBox
                  name={'tiporecurso'}
                  dataForm={instanciaData}
                  value={instanciaData.tiporecurso}
                  setValue={addValorTipoRecurso}
                  label={'Tipo Recurso'}
                  />

                  <InputInput
                  type='text'
                  maxLength={25}
                  id='zkey'
                  label='ZKey'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='zkey'
                  value={instanciaData.zkey}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='zkeyquem'
                  label='ZKeyQuem'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='zkeyquem'
                  value={instanciaData.zkeyquem}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='zkeyquando'
                  label='ZKeyQuando'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='zkeyquando'
                  value={instanciaData.zkeyquando}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={25}
                  id='nroantigo'
                  label='NroAntigo'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='nroantigo'
                  value={instanciaData.nroantigo}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={100}
                  id='accesscode'
                  label='AccessCode'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='accesscode'
                  value={instanciaData.accesscode}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='julgador'
                  label='Julgador'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='julgador'
                  value={instanciaData.julgador}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={25}
                  id='zkeyia'
                  label='ZKeyIA'
                  dataForm={instanciaData}
                  className='inputIncNome'
                  name='zkeyia'
                  value={instanciaData.zkeyia}
                  onChange={onChange}
                  />

                </div>
              </form>


              {isMobile && (
                <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Instancia' data={instanciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`InstanciaForm-${instanciaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                )}
                <DeleteButton page={'/pages/instancia'} id={instanciaData.id} closeModel={onClose} dadoApi={dadoApi} />
              </div>
              <div className='form-spacer'></div>
              </>
            );
          };