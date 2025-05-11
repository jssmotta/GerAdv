// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IHorasTrab } from '@/app/GerAdv_TS/HorasTrab/Interfaces/interface.HorasTrab';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

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
  }
  
  export const HorasTrabForm: React.FC<HorasTrabFormProps> = ({
    horastrabData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
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
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (horastrabData.id === 0) {
    horastrabData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (horastrabData.id === 0) {
    horastrabData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (horastrabData.id === 0) {
    horastrabData.advogado = getParamFromUrl("advogados");
  }
}
 
if (getParamFromUrl("funcionarios") > 0) {
  funcionariosApi
    .getById(getParamFromUrl("funcionarios"))
    .then((response) => {
      setNomeFuncionarios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (horastrabData.id === 0) {
    horastrabData.funcionario = getParamFromUrl("funcionarios");
  }
}
 
if (getParamFromUrl("servicos") > 0) {
  servicosApi
    .getById(getParamFromUrl("servicos"))
    .then((response) => {
      setNomeServicos(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (horastrabData.id === 0) {
    horastrabData.servico = getParamFromUrl("servicos");
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
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de HorasTrab:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`HorasTrabForm-${horastrabData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar HorasTrab diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-HorasTrab' : 'form-container form-container-HorasTrab'}>
       
            <form className='formInputCadInc' id={`HorasTrabForm-${horastrabData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={horastrabData} isSubmitting={isSubmitting} onClose={onClose} formId={`HorasTrabForm-${horastrabData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="idcontatocrm"
label="IDContatoCRM"
className="inputIncNome"
name="idcontatocrm"
value={horastrabData.idcontatocrm}
onChange={onChange}               
/>

<InputCheckbox label="Honorario" name="honorario" checked={horastrabData.honorario} onChange={onChange} />
        
<InputInput
type="text"
id="idagenda"
label="IDAgenda"
className="inputIncNome"
name="idagenda"
value={horastrabData.idagenda}
onChange={onChange}               
/>

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={horastrabData.data}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={horastrabData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="status"
label="Status"
className="inputIncNome"
name="status"
value={horastrabData.status}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={horastrabData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <AdvogadosComboBox
            name={'advogado'}
            value={horastrabData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

            <FuncionariosComboBox
            name={'funcionario'}
            value={horastrabData.funcionario}
            setValue={addValorFuncionario}
            label={'Colaborador'}
            />

</div><div className="grid-container">        
<InputInput
type="text"
id="hrini"
label="HrIni"
className="inputIncNome"
name="hrini"
value={horastrabData.hrini}
onChange={onChange}               
/>

<InputInput
type="text"
id="hrfim"
label="HrFim"
className="inputIncNome"
name="hrfim"
value={horastrabData.hrfim}
onChange={onChange}               
/>

<InputInput
type="text"
id="tempo"
label="Tempo"
className="inputIncNome"
name="tempo"
value={horastrabData.tempo}
onChange={onChange}               
/>

<InputInput
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={horastrabData.valor}
onChange={onChange}               
/>

<InputInput
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={horastrabData.obs}
onChange={onChange}               
/>

<InputInput
type="text"
id="anexo"
label="Anexo"
className="inputIncNome"
name="anexo"
value={horastrabData.anexo}
onChange={onChange}               
/>

<InputInput
type="text"
id="anexocomp"
label="AnexoComp"
className="inputIncNome"
name="anexocomp"
value={horastrabData.anexocomp}
onChange={onChange}               
/>

<InputInput
type="text"
id="anexounc"
label="AnexoUNC"
className="inputIncNome"
name="anexounc"
value={horastrabData.anexounc}
onChange={onChange}               
/>

            <ServicosComboBox
            name={'servico'}
            value={horastrabData.servico}
            setValue={addValorServico}
            label={'Serviços'}
            />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 