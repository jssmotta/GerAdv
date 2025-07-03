// Tracking: Forms.tsx.txt
'use client';
import { IAgendaFinanceiro } from '@/app/GerAdv_TS/AgendaFinanceiro/Interfaces/interface.AgendaFinanceiro';
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
import { AgendaFinanceiroApi } from '../../Apis/ApiAgendaFinanceiro';
import { useValidationsAgendaFinanceiro } from '../../Hooks/hookAgendaFinanceiro';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import FuncionariosComboBox from '@/app/GerAdv_TS/Funcionarios/ComboBox/Funcionarios';
import TipoCompromissoComboBox from '@/app/GerAdv_TS/TipoCompromisso/ComboBox/TipoCompromisso';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import PrepostosComboBox from '@/app/GerAdv_TS/Prepostos/ComboBox/Prepostos';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { FuncionariosApi } from '@/app/GerAdv_TS/Funcionarios/Apis/ApiFuncionarios';
import { TipoCompromissoApi } from '@/app/GerAdv_TS/TipoCompromisso/Apis/ApiTipoCompromisso';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { PrepostosApi } from '@/app/GerAdv_TS/Prepostos/Apis/ApiPrepostos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface AgendaFinanceiroFormProps {
  agendafinanceiroData: IAgendaFinanceiro;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AgendaFinanceiroForm: React.FC<AgendaFinanceiroFormProps> = ({
  agendafinanceiroData, 
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
const dadoApi = new AgendaFinanceiroApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAgendaFinanceiro();
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAdvogados, setNomeAdvogados] = useState('');
const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncionarios, setNomeFuncionarios] = useState('');
const funcionariosApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoCompromisso, setNomeTipoCompromisso] = useState('');
const tipocompromissoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrepostos, setNomePrepostos] = useState('');
const prepostosApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('cidade') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.cidade = getParamFromUrl('cidade');
  }
}

if (getParamFromUrl('advogados') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.advogado == 0) {
    advogadosApi
    .getById(getParamFromUrl('advogados'))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.advogado = getParamFromUrl('advogados');
  }
}

if (getParamFromUrl('funcionarios') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.funcionario == 0) {
    funcionariosApi
    .getById(getParamFromUrl('funcionarios'))
    .then((response) => {
      setNomeFuncionarios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.funcionario = getParamFromUrl('funcionarios');
  }
}

if (getParamFromUrl('tipocompromisso') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.tipocompromisso == 0) {
    tipocompromissoApi
    .getById(getParamFromUrl('tipocompromisso'))
    .then((response) => {
      setNomeTipoCompromisso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.tipocompromisso = getParamFromUrl('tipocompromisso');
  }
}

if (getParamFromUrl('clientes') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('area') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.area = getParamFromUrl('area');
  }
}

if (getParamFromUrl('justica') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.justica = getParamFromUrl('justica');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('operador') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.usuario == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.usuario = getParamFromUrl('operador');
  }
}

if (getParamFromUrl('prepostos') > 0) {
  if (agendafinanceiroData.id === 0 && agendafinanceiroData.preposto == 0) {
    prepostosApi
    .getById(getParamFromUrl('prepostos'))
    .then((response) => {
      setNomePrepostos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendafinanceiroData.preposto = getParamFromUrl('prepostos');
  }
}
const addValorCidade = (e: any) => {
  if (e?.id>0)
    agendafinanceiroData.cidade = e.id;
  };
  const addValorAdvogado = (e: any) => {
    if (e?.id>0)
      agendafinanceiroData.advogado = e.id;
    };
    const addValorFuncionario = (e: any) => {
      if (e?.id>0)
        agendafinanceiroData.funcionario = e.id;
      };
      const addValorTipoCompromisso = (e: any) => {
        if (e?.id>0)
          agendafinanceiroData.tipocompromisso = e.id;
        };
        const addValorCliente = (e: any) => {
          if (e?.id>0)
            agendafinanceiroData.cliente = e.id;
          };
          const addValorArea = (e: any) => {
            if (e?.id>0)
              agendafinanceiroData.area = e.id;
            };
            const addValorJustica = (e: any) => {
              if (e?.id>0)
                agendafinanceiroData.justica = e.id;
              };
              const addValorProcesso = (e: any) => {
                if (e?.id>0)
                  agendafinanceiroData.processo = e.id;
                };
                const addValorUsuario = (e: any) => {
                  if (e?.id>0)
                    agendafinanceiroData.usuario = e.id;
                  };
                  const addValorPreposto = (e: any) => {
                    if (e?.id>0)
                      agendafinanceiroData.preposto = e.id;
                    };
                    const onConfirm = (e: React.FormEvent) => {
                      e.preventDefault();
                      if (e.stopPropagation) e.stopPropagation();

                        if (!isSubmitting) {
                          setIsSubmitting(true);

                          try {
                            onSubmit(e);
                          } catch (error) {
                          console.error('Erro ao submeter formulário de AgendaFinanceiro:', error);
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
                            target: document.getElementById(`AgendaFinanceiroForm-${agendafinanceiroData.id}`)
                          } as unknown as React.FormEvent;

                          onSubmit(syntheticEvent);
                        } catch (error) {
                        console.error('Erro ao salvar AgendaFinanceiro diretamente:', error);
                        setIsSubmitting(false);
                        if (onError) onError();
                        }
                      }
                    };
                    useEffect(() => {
                      const el = document.querySelector('.nameFormMobile');
                      if (el) {
                        el.textContent = agendafinanceiroData?.id == 0 ? 'Editar AgendaFinanceiro' : 'Adicionar Agenda Financeiro';
                      }
                    }, [agendafinanceiroData.id]);
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

                      <div className={isMobile ? 'form-container form-container-AgendaFinanceiro' : 'form-container form-container-AgendaFinanceiro'}>

                        <form className='formInputCadInc' id={`AgendaFinanceiroForm-${agendafinanceiroData.id}`} onSubmit={onConfirm}>
                          {!isMobile && (
                            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AgendaFinanceiro' data={agendafinanceiroData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaFinanceiroForm-${agendafinanceiroData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                            )}
                            <div className='grid-container'>


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='idcob'
                              label='IDCOB'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='idcob'
                              value={agendafinanceiroData.idcob}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='idne'
                              label='IDNE'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='idne'
                              value={agendafinanceiroData.idne}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='prazoprovisionado'
                              label='PrazoProvisionado'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='prazoprovisionado'
                              value={agendafinanceiroData.prazoprovisionado}
                              onChange={onChange}
                              />


                              <CidadeComboBox
                              name={'cidade'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.cidade}
                              setValue={addValorCidade}
                              label={'Cidade'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='oculto'
                              label='Oculto'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='oculto'
                              value={agendafinanceiroData.oculto}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='cartaprecatoria'
                              label='CartaPrecatoria'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='cartaprecatoria'
                              value={agendafinanceiroData.cartaprecatoria}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='repetirdias'
                              label='RepetirDias'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='repetirdias'
                              value={agendafinanceiroData.repetirdias}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='hrfinal'
                              label='HrFinal'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='hrfinal'
                              value={agendafinanceiroData.hrfinal}
                              onChange={onChange}
                              />

                            </div><div className='grid-container'>
                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='repetir'
                              label='Repetir'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='repetir'
                              value={agendafinanceiroData.repetir}
                              onChange={onChange}
                              />


                              <AdvogadosComboBox
                              name={'advogado'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.advogado}
                              setValue={addValorAdvogado}
                              label={'Advogados'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='eventogerador'
                              label='EventoGerador'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='eventogerador'
                              value={agendafinanceiroData.eventogerador}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='eventodata'
                              label='EventoData'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='eventodata'
                              value={agendafinanceiroData.eventodata}
                              onChange={onChange}
                              />


                              <FuncionariosComboBox
                              name={'funcionario'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.funcionario}
                              setValue={addValorFuncionario}
                              label={'Colaborador'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='data'
                              label='Data'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='data'
                              value={agendafinanceiroData.data}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='eventoprazo'
                              label='EventoPrazo'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='eventoprazo'
                              value={agendafinanceiroData.eventoprazo}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='hora'
                              label='Hora'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='hora'
                              value={agendafinanceiroData.hora}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2147483647}
                              id='compromisso'
                              label='Compromisso'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='compromisso'
                              value={agendafinanceiroData.compromisso}
                              onChange={onChange}
                              />

                            </div><div className='grid-container'>
                              <TipoCompromissoComboBox
                              name={'tipocompromisso'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.tipocompromisso}
                              setValue={addValorTipoCompromisso}
                              label={'Tipo Compromisso'}
                              />

                              <ClientesComboBox
                              name={'cliente'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.cliente}
                              setValue={addValorCliente}
                              label={'Clientes'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='ddias'
                              label='DDias'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='ddias'
                              value={agendafinanceiroData.ddias}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='dias'
                              label='Dias'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='dias'
                              value={agendafinanceiroData.dias}
                              onChange={onChange}
                              />

                              <InputCheckbox dataForm={agendafinanceiroData} label='Liberado' name='liberado' checked={agendafinanceiroData.liberado} onChange={onChange} />
                              <InputCheckbox dataForm={agendafinanceiroData} label='Importante' name='importante' checked={agendafinanceiroData.importante} onChange={onChange} />
                              <InputCheckbox dataForm={agendafinanceiroData} label='Concluido' name='concluido' checked={agendafinanceiroData.concluido} onChange={onChange} />

                              <AreaComboBox
                              name={'area'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.area}
                              setValue={addValorArea}
                              label={'Area'}
                              />

                              <JusticaComboBox
                              name={'justica'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.justica}
                              setValue={addValorJustica}
                              label={'Justica'}
                              />
                            </div><div className='grid-container'>
                              <ProcessosComboBox
                              name={'processo'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.processo}
                              setValue={addValorProcesso}
                              label={'Processos'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='idhistorico'
                              label='IDHistorico'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='idhistorico'
                              value={agendafinanceiroData.idhistorico}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='idinsprocesso'
                              label='IDInsProcesso'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='idinsprocesso'
                              value={agendafinanceiroData.idinsprocesso}
                              onChange={onChange}
                              />


                              <OperadorComboBox
                              name={'usuario'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.usuario}
                              setValue={addValorUsuario}
                              label={'Operador'}
                              />

                              <PrepostosComboBox
                              name={'preposto'}
                              dataForm={agendafinanceiroData}
                              value={agendafinanceiroData.preposto}
                              setValue={addValorPreposto}
                              label={'Prepostos'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='quemid'
                              label='QuemID'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='quemid'
                              value={agendafinanceiroData.quemid}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='quemcodigo'
                              label='QuemCodigo'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='quemcodigo'
                              value={agendafinanceiroData.quemcodigo}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2147483647}
                              id='status'
                              label='Status'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='status'
                              value={agendafinanceiroData.status}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='valor'
                              label='Valor'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='valor'
                              value={agendafinanceiroData.valor}
                              onChange={onChange}
                              />

                            </div><div className='grid-container'>
                              <InputInput
                              type='text'
                              maxLength={2147483647}
                              id='compromissohtml'
                              label='CompromissoHTML'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='compromissohtml'
                              value={agendafinanceiroData.compromissohtml}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='decisao'
                              label='Decisao'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='decisao'
                              value={agendafinanceiroData.decisao}
                              onChange={onChange}
                              />

                              <InputCheckbox dataForm={agendafinanceiroData} label='Revisar' name='revisar' checked={agendafinanceiroData.revisar} onChange={onChange} />
                              <InputCheckbox dataForm={agendafinanceiroData} label='RevisarP2' name='revisarp2' checked={agendafinanceiroData.revisarp2} onChange={onChange} />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='sempre'
                              label='Sempre'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='sempre'
                              value={agendafinanceiroData.sempre}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='prazodias'
                              label='PrazoDias'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='prazodias'
                              value={agendafinanceiroData.prazodias}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='protocolointegrado'
                              label='ProtocoloIntegrado'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='protocolointegrado'
                              value={agendafinanceiroData.protocolointegrado}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='datainicioprazo'
                              label='DataInicioPrazo'
                              dataForm={agendafinanceiroData}
                              className='inputIncNome'
                              name='datainicioprazo'
                              value={agendafinanceiroData.datainicioprazo}
                              onChange={onChange}
                              />

                              <InputCheckbox dataForm={agendafinanceiroData} label='UsuarioCiente' name='usuariociente' checked={agendafinanceiroData.usuariociente} onChange={onChange} />
                            </div>
                          </form>


                          {isMobile && (
                            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AgendaFinanceiro' data={agendafinanceiroData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaFinanceiroForm-${agendafinanceiroData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                            )}
                            <DeleteButton page={'/pages/agendafinanceiro'} id={agendafinanceiroData.id} closeModel={onClose} dadoApi={dadoApi} />
                          </div>
                          <div className='form-spacer'></div>
                          </>
                        );
                      };