// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAgendaRepetir } from '@/app/GerAdv_TS/AgendaRepetir/Interfaces/interface.AgendaRepetir';
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

import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import FuncionariosComboBox from '@/app/GerAdv_TS/Funcionarios/ComboBox/Funcionarios';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { FuncionariosApi } from '@/app/GerAdv_TS/Funcionarios/Apis/ApiFuncionarios';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface AgendaRepetirFormProps {
    agendarepetirData: IAgendaRepetir;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const AgendaRepetirForm: React.FC<AgendaRepetirFormProps> = ({
    agendarepetirData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeAdvogados, setNomeAdvogados] = useState('');
            const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncionarios, setNomeFuncionarios] = useState('');
            const funcionariosApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendarepetirData.id === 0) {
    agendarepetirData.advogado = getParamFromUrl("advogados");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (agendarepetirData.id === 0) {
    agendarepetirData.cliente = getParamFromUrl("clientes");
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

  if (agendarepetirData.id === 0) {
    agendarepetirData.funcionario = getParamFromUrl("funcionarios");
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

  if (agendarepetirData.id === 0) {
    agendarepetirData.processo = getParamFromUrl("processos");
  }
}
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        agendarepetirData.advogado = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        agendarepetirData.cliente = e.id;
                      };
 const addValorFuncionario = (e: any) => {
                        if (e?.id>0)
                        agendarepetirData.funcionario = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        agendarepetirData.processo = e.id;
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
        console.error("Erro ao submeter formulário de AgendaRepetir:", error);
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
          target: document.getElementById(`AgendaRepetirForm-${agendarepetirData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar AgendaRepetir diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-AgendaRepetir' : 'form-container form-container-AgendaRepetir'}>
       
            <form className='formInputCadInc' id={`AgendaRepetirForm-${agendarepetirData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={agendarepetirData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaRepetirForm-${agendarepetirData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <AdvogadosComboBox
            name={'advogado'}
            value={agendarepetirData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={agendarepetirData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="datafinal"
label="DataFinal"
className="inputIncNome"
name="datafinal"
value={agendarepetirData.datafinal}
onChange={onChange}               
/>

            <FuncionariosComboBox
            name={'funcionario'}
            value={agendarepetirData.funcionario}
            setValue={addValorFuncionario}
            label={'Colaborador'}
            />

<InputInput
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={agendarepetirData.horafinal}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={agendarepetirData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputCheckbox label="Pessoal" name="pessoal" checked={agendarepetirData.pessoal} onChange={onChange} />
        
<InputInput
type="text"
id="frequencia"
label="Frequencia"
className="inputIncNome"
name="frequencia"
value={agendarepetirData.frequencia}
onChange={onChange}               
/>

<InputInput
type="text"
id="dia"
label="Dia"
className="inputIncNome"
name="dia"
value={agendarepetirData.dia}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="mes"
label="Mes"
className="inputIncNome"
name="mes"
value={agendarepetirData.mes}
onChange={onChange}               
/>

<InputInput
type="text"
id="hora"
label="Hora"
className="inputIncNome"
name="hora"
value={agendarepetirData.hora}
onChange={onChange}               
/>

<InputInput
type="text"
id="idquem"
label="IDQuem"
className="inputIncNome"
name="idquem"
value={agendarepetirData.idquem}
onChange={onChange}               
/>

<InputInput
type="text"
id="idquem2"
label="IDQuem2"
className="inputIncNome"
name="idquem2"
value={agendarepetirData.idquem2}
onChange={onChange}               
/>

<InputInput
type="text"
id="mensagem"
label="Mensagem"
className="inputIncNome"
name="mensagem"
value={agendarepetirData.mensagem}
onChange={onChange}               
/>

<InputInput
type="text"
id="idtipo"
label="IDTipo"
className="inputIncNome"
name="idtipo"
value={agendarepetirData.idtipo}
onChange={onChange}               
/>

<InputInput
type="text"
id="id1"
label="ID1"
className="inputIncNome"
name="id1"
value={agendarepetirData.id1}
onChange={onChange}               
/>

<InputInput
type="text"
id="id2"
label="ID2"
className="inputIncNome"
name="id2"
value={agendarepetirData.id2}
onChange={onChange}               
/>

<InputInput
type="text"
id="id3"
label="ID3"
className="inputIncNome"
name="id3"
value={agendarepetirData.id3}
onChange={onChange}               
/>

<InputInput
type="text"
id="id4"
label="ID4"
className="inputIncNome"
name="id4"
value={agendarepetirData.id4}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Segunda" name="segunda" checked={agendarepetirData.segunda} onChange={onChange} />
<InputCheckbox label="Quarta" name="quarta" checked={agendarepetirData.quarta} onChange={onChange} />
<InputCheckbox label="Quinta" name="quinta" checked={agendarepetirData.quinta} onChange={onChange} />
<InputCheckbox label="Sexta" name="sexta" checked={agendarepetirData.sexta} onChange={onChange} />
<InputCheckbox label="Sabado" name="sabado" checked={agendarepetirData.sabado} onChange={onChange} />
<InputCheckbox label="Domingo" name="domingo" checked={agendarepetirData.domingo} onChange={onChange} />
<InputCheckbox label="Terca" name="terca" checked={agendarepetirData.terca} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 