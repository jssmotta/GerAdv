// Tracking: Forms.tsx.txt
'use client';
import { IHorasTrab } from '@/app/GerAdv_TS/HorasTrab/Interfaces/interface.HorasTrab';
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
import { HorasTrabApi } from '../../Apis/ApiHorasTrab';
import { useValidationsHorasTrab } from '../../Hooks/hookHorasTrab';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import FuncionariosComboBox from '@/app/GerAdv_TS/Funcionarios/ComboBox/Funcionarios';
import ServicosComboBox from '@/app/GerAdv_TS/Servicos/ComboBox/Servicos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { FuncionariosApi } from '@/app/GerAdv_TS/Funcionarios/Apis/ApiFuncionarios';
import { ServicosApi } from '@/app/GerAdv_TS/Servicos/Apis/ApiServicos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface HorasTrabFormProps {
  horastrabData: IHorasTrab;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const HorasTrabForm: React.FC<HorasTrabFormProps> = ({
  horastrabData, 
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
const dadoApi = new HorasTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsHorasTrab();
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAdvogados, setNomeAdvogados] = useState('');
const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncionarios, setNomeFuncionarios] = useState('');
const funcionariosApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeServicos, setNomeServicos] = useState('');
const servicosApi = new ServicosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('clientes') > 0) {
  if (horastrabData.id === 0 && horastrabData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    horastrabData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (horastrabData.id === 0 && horastrabData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    horastrabData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('advogados') > 0) {
  if (horastrabData.id === 0 && horastrabData.advogado == 0) {
    advogadosApi
    .getById(getParamFromUrl('advogados'))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    horastrabData.advogado = getParamFromUrl('advogados');
  }
}

if (getParamFromUrl('funcionarios') > 0) {
  if (horastrabData.id === 0 && horastrabData.funcionario == 0) {
    funcionariosApi
    .getById(getParamFromUrl('funcionarios'))
    .then((response) => {
      setNomeFuncionarios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    horastrabData.funcionario = getParamFromUrl('funcionarios');
  }
}

if (getParamFromUrl('servicos') > 0) {
  if (horastrabData.id === 0 && horastrabData.servico == 0) {
    servicosApi
    .getById(getParamFromUrl('servicos'))
    .then((response) => {
      setNomeServicos(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    horastrabData.servico = getParamFromUrl('servicos');
  }
}
const addValorCliente = (e: any) => {
  if (e?.id>0)
    horastrabData.cliente = e.id;
  };
  const addValorProcesso = (e: any) => {
    if (e?.id>0)
      horastrabData.processo = e.id;
    };
    const addValorAdvogado = (e: any) => {
      if (e?.id>0)
        horastrabData.advogado = e.id;
      };
      const addValorFuncionario = (e: any) => {
        if (e?.id>0)
          horastrabData.funcionario = e.id;
        };
        const addValorServico = (e: any) => {
          if (e?.id>0)
            horastrabData.servico = e.id;
          };
          const onConfirm = (e: React.FormEvent) => {
            e.preventDefault();
            if (e.stopPropagation) e.stopPropagation();

              if (!isSubmitting) {
                setIsSubmitting(true);

                try {
                  onSubmit(e);
                } catch (error) {
                console.error('Erro ao submeter formulário de HorasTrab:', error);
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
                  target: document.getElementById(`HorasTrabForm-${horastrabData.id}`)
                } as unknown as React.FormEvent;

                onSubmit(syntheticEvent);
              } catch (error) {
              console.error('Erro ao salvar HorasTrab diretamente:', error);
              setIsSubmitting(false);
              if (onError) onError();
              }
            }
          };
          useEffect(() => {
            const el = document.querySelector('.nameFormMobile');
            if (el) {
              el.textContent = horastrabData?.id == 0 ? 'Editar HorasTrab' : 'Adicionar Horas Trab';
            }
          }, [horastrabData.id]);
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

            <div className={isMobile ? 'form-container form-container-HorasTrab' : 'form-container form-container-HorasTrab'}>

              <form className='formInputCadInc' id={`HorasTrabForm-${horastrabData.id}`} onSubmit={onConfirm}>
                {!isMobile && (
                  <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='HorasTrab' data={horastrabData} isSubmitting={isSubmitting} onClose={onClose} formId={`HorasTrabForm-${horastrabData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                  )}
                  <div className='grid-container'>


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='idcontatocrm'
                    label='IDContatoCRM'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='idcontatocrm'
                    value={horastrabData.idcontatocrm}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={horastrabData} label='Honorario' name='honorario' checked={horastrabData.honorario} onChange={onChange} />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='idagenda'
                    label='IDAgenda'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='idagenda'
                    value={horastrabData.idagenda}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='data'
                    label='Data'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='data'
                    value={horastrabData.data}
                    onChange={onChange}
                    />


                    <ClientesComboBox
                    name={'cliente'}
                    dataForm={horastrabData}
                    value={horastrabData.cliente}
                    setValue={addValorCliente}
                    label={'Clientes'}
                    />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='status'
                    label='Status'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='status'
                    value={horastrabData.status}
                    onChange={onChange}
                    />


                    <ProcessosComboBox
                    name={'processo'}
                    dataForm={horastrabData}
                    value={horastrabData.processo}
                    setValue={addValorProcesso}
                    label={'Processos'}
                    />

                    <AdvogadosComboBox
                    name={'advogado'}
                    dataForm={horastrabData}
                    value={horastrabData.advogado}
                    setValue={addValorAdvogado}
                    label={'Advogados'}
                    />

                    <FuncionariosComboBox
                    name={'funcionario'}
                    dataForm={horastrabData}
                    value={horastrabData.funcionario}
                    setValue={addValorFuncionario}
                    label={'Colaborador'}
                    />
                  </div><div className='grid-container'>
                    <InputInput
                    type='text'
                    maxLength={5}
                    id='hrini'
                    label='HrIni'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='hrini'
                    value={horastrabData.hrini}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={5}
                    id='hrfim'
                    label='HrFim'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='hrfim'
                    value={horastrabData.hrfim}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='tempo'
                    label='Tempo'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='tempo'
                    value={horastrabData.tempo}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='valor'
                    label='Valor'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='valor'
                    value={horastrabData.valor}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2147483647}
                    id='obs'
                    label='OBS'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='obs'
                    value={horastrabData.obs}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={255}
                    id='anexo'
                    label='Anexo'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='anexo'
                    value={horastrabData.anexo}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={50}
                    id='anexocomp'
                    label='AnexoComp'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='anexocomp'
                    value={horastrabData.anexocomp}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={255}
                    id='anexounc'
                    label='AnexoUNC'
                    dataForm={horastrabData}
                    className='inputIncNome'
                    name='anexounc'
                    value={horastrabData.anexounc}
                    onChange={onChange}
                    />


                    <ServicosComboBox
                    name={'servico'}
                    dataForm={horastrabData}
                    value={horastrabData.servico}
                    setValue={addValorServico}
                    label={'Serviço'}
                    />
                  </div>
                </form>


                {isMobile && (
                  <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='HorasTrab' data={horastrabData} isSubmitting={isSubmitting} onClose={onClose} formId={`HorasTrabForm-${horastrabData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                  )}
                  <DeleteButton page={'/pages/horastrab'} id={horastrabData.id} closeModel={onClose} dadoApi={dadoApi} />
                </div>
                <div className='form-spacer'></div>
                </>
              );
            };