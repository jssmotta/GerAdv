// Tracking: Forms.tsx.txt
'use client';
import { IAdvogados } from '@/app/GerAdv_TS/Advogados/Interfaces/interface.Advogados';
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
import { AdvogadosApi } from '../../Apis/ApiAdvogados';
import { useValidationsAdvogados } from '../../Hooks/hookAdvogados';
import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import EscritoriosComboBox from '@/app/GerAdv_TS/Escritorios/ComboBox/Escritorios';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import { EscritoriosApi } from '@/app/GerAdv_TS/Escritorios/Apis/ApiEscritorios';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCpf from '@/app/components/Inputs/InputCpf'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
import InputCep from '@/app/components/Inputs/InputCep'
interface AdvogadosFormProps {
  advogadosData: IAdvogados;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AdvogadosForm: React.FC<AdvogadosFormProps> = ({
  advogadosData, 
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
const dadoApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAdvogados();
const [nomeCargos, setNomeCargos] = useState('');
const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeEscritorios, setNomeEscritorios] = useState('');
const escritoriosApi = new EscritoriosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('cargos') > 0) {
  if (advogadosData.id === 0 && advogadosData.cargo == 0) {
    cargosApi
    .getById(getParamFromUrl('cargos'))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    advogadosData.cargo = getParamFromUrl('cargos');
  }
}

if (getParamFromUrl('escritorios') > 0) {
  if (advogadosData.id === 0 && advogadosData.escritorio == 0) {
    escritoriosApi
    .getById(getParamFromUrl('escritorios'))
    .then((response) => {
      setNomeEscritorios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    advogadosData.escritorio = getParamFromUrl('escritorios');
  }
}

if (getParamFromUrl('cidade') > 0) {
  if (advogadosData.id === 0 && advogadosData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    advogadosData.cidade = getParamFromUrl('cidade');
  }
}
const addValorCargo = (e: any) => {
  if (e?.id>0)
    advogadosData.cargo = e.id;
  };
  const addValorEscritorio = (e: any) => {
    if (e?.id>0)
      advogadosData.escritorio = e.id;
    };
    const addValorCidade = (e: any) => {
      if (e?.id>0)
        advogadosData.cidade = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de Advogados:', error);
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
              target: document.getElementById(`AdvogadosForm-${advogadosData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar Advogados diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = advogadosData?.id == 0 ? 'Editar Advogados' : 'Adicionar Advogados';
        }
      }, [advogadosData.id]);
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

        <div className={isMobile ? 'form-container form-container-Advogados' : 'form-container form-container-Advogados'}>

          <form className='formInputCadInc' id={`AdvogadosForm-${advogadosData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Advogados' data={advogadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AdvogadosForm-${advogadosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>

                <InputName
                type='text'
                id='nome'
                label='Nome'
                dataForm={advogadosData}
                className='inputIncNome'
                name='nome'
                value={advogadosData.nome}
                placeholder={`Informe Nome`}
                onChange={onChange}
                required
                />

                <CargosComboBox
                name={'cargo'}
                dataForm={advogadosData}
                value={advogadosData.cargo}
                setValue={addValorCargo}
                label={'Cargo'}
                />

                <InputInput
                type='email'
                maxLength={255}
                id='emailpro'
                label='EMailPro'
                dataForm={advogadosData}
                className='inputIncNome'
                name='emailpro'
                value={advogadosData.emailpro}
                onChange={onChange}
                />


                <InputCpf
                type='text'
                id='cpf'
                label='CPF'
                dataForm={advogadosData}
                className='inputIncNome'
                name='cpf'
                value={advogadosData.cpf}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={30}
                id='rg'
                label='RG'
                dataForm={advogadosData}
                className='inputIncNome'
                name='rg'
                value={advogadosData.rg}
                onChange={onChange}
                />

                <InputCheckbox dataForm={advogadosData} label='Casa' name='casa' checked={advogadosData.casa} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={80}
                id='nomemae'
                label='NomeMae'
                dataForm={advogadosData}
                className='inputIncNome'
                name='nomemae'
                value={advogadosData.nomemae}
                onChange={onChange}
                />


                <EscritoriosComboBox
                name={'escritorio'}
                dataForm={advogadosData}
                value={advogadosData.escritorio}
                setValue={addValorEscritorio}
                label={'Escritorios'}
                />
                <InputCheckbox dataForm={advogadosData} label='Estagiario' name='estagiario' checked={advogadosData.estagiario} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={12}
                id='oab'
                label='OAB'
                dataForm={advogadosData}
                className='inputIncNome'
                name='oab'
                value={advogadosData.oab}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={50}
                id='nomecompleto'
                label='NomeCompleto'
                dataForm={advogadosData}
                className='inputIncNome'
                name='nomecompleto'
                value={advogadosData.nomecompleto}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={80}
                id='endereco'
                label='Endereco'
                dataForm={advogadosData}
                className='inputIncNome'
                name='endereco'
                value={advogadosData.endereco}
                onChange={onChange}
                />


                <CidadeComboBox
                name={'cidade'}
                dataForm={advogadosData}
                value={advogadosData.cidade}
                setValue={addValorCidade}
                label={'Cidade'}
                />

                <InputCep
                type='text'
                id='cep'
                label='CEP'
                dataForm={advogadosData}
                className='inputIncNome'
                name='cep'
                value={advogadosData.cep}
                onChange={onChange}
                />

                <InputCheckbox dataForm={advogadosData} label='Sexo' name='sexo' checked={advogadosData.sexo} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={50}
                id='bairro'
                label='Bairro'
                dataForm={advogadosData}
                className='inputIncNome'
                name='bairro'
                value={advogadosData.bairro}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={10}
                id='ctpsserie'
                label='CTPSSerie'
                dataForm={advogadosData}
                className='inputIncNome'
                name='ctpsserie'
                value={advogadosData.ctpsserie}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={15}
                id='ctps'
                label='CTPS'
                dataForm={advogadosData}
                className='inputIncNome'
                name='ctps'
                value={advogadosData.ctps}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fone'
                label='Fone'
                dataForm={advogadosData}
                className='inputIncNome'
                name='fone'
                value={advogadosData.fone}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fax'
                label='Fax'
                dataForm={advogadosData}
                className='inputIncNome'
                name='fax'
                value={advogadosData.fax}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={2048}
                id='comissao'
                label='Comissao'
                dataForm={advogadosData}
                className='inputIncNome'
                name='comissao'
                value={advogadosData.comissao}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='dtinicio'
                label='DtInicio'
                dataForm={advogadosData}
                className='inputIncNome'
                name='dtinicio'
                value={advogadosData.dtinicio}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='dtfim'
                label='DtFim'
                dataForm={advogadosData}
                className='inputIncNome'
                name='dtfim'
                value={advogadosData.dtfim}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='dtnasc'
                label='DtNasc'
                dataForm={advogadosData}
                className='inputIncNome'
                name='dtnasc'
                value={advogadosData.dtnasc}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='salario'
                label='Salario'
                dataForm={advogadosData}
                className='inputIncNome'
                name='salario'
                value={advogadosData.salario}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={20}
                id='secretaria'
                label='Secretaria'
                dataForm={advogadosData}
                className='inputIncNome'
                name='secretaria'
                value={advogadosData.secretaria}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={200}
                id='textoprocuracao'
                label='TextoProcuracao'
                dataForm={advogadosData}
                className='inputIncNome'
                name='textoprocuracao'
                value={advogadosData.textoprocuracao}
                onChange={onChange}
                />


                <InputInput
                type='email'
                maxLength={100}
                id='email'
                label='EMail'
                dataForm={advogadosData}
                className='inputIncNome'
                name='email'
                value={advogadosData.email}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='especializacao'
                label='Especializacao'
                dataForm={advogadosData}
                className='inputIncNome'
                name='especializacao'
                value={advogadosData.especializacao}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={200}
                id='pasta'
                label='Pasta'
                dataForm={advogadosData}
                className='inputIncNome'
                name='pasta'
                value={advogadosData.pasta}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={2147483647}
                id='observacao'
                label='Observacao'
                dataForm={advogadosData}
                className='inputIncNome'
                name='observacao'
                value={advogadosData.observacao}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='contabancaria'
                label='ContaBancaria'
                dataForm={advogadosData}
                className='inputIncNome'
                name='contabancaria'
                value={advogadosData.contabancaria}
                onChange={onChange}
                />

                <InputCheckbox dataForm={advogadosData} label='ParcTop' name='parctop' checked={advogadosData.parctop} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={1}
                id='class'
                label='Class'
                dataForm={advogadosData}
                className='inputIncNome'
                name='class'
                value={advogadosData.class}
                onChange={onChange}
                />

                <InputCheckbox dataForm={advogadosData} label='Top' name='top' checked={advogadosData.top} onChange={onChange} />
                <InputCheckbox dataForm={advogadosData} label='Ani' name='ani' checked={advogadosData.ani} onChange={onChange} />
              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Advogados' data={advogadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AdvogadosForm-${advogadosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/advogados'} id={advogadosData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };