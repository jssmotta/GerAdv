// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IInstancia } from '@/app/GerAdv_TS/Instancia/Interfaces/interface.Instancia';
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
  }
  
  export const InstanciaForm: React.FC<InstanciaFormProps> = ({
    instanciaData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAcao, setNomeAcao] = useState('');
            const acaoApi = new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeForo, setNomeForo] = useState('');
            const foroApi = new ForoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoRecurso, setNomeTipoRecurso] = useState('');
            const tiporecursoApi = new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (instanciaData.id === 0) {
    instanciaData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("acao") > 0) {
  acaoApi
    .getById(getParamFromUrl("acao"))
    .then((response) => {
      setNomeAcao(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (instanciaData.id === 0) {
    instanciaData.acao = getParamFromUrl("acao");
  }
}
 
if (getParamFromUrl("foro") > 0) {
  foroApi
    .getById(getParamFromUrl("foro"))
    .then((response) => {
      setNomeForo(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (instanciaData.id === 0) {
    instanciaData.foro = getParamFromUrl("foro");
  }
}
 
if (getParamFromUrl("tiporecurso") > 0) {
  tiporecursoApi
    .getById(getParamFromUrl("tiporecurso"))
    .then((response) => {
      setNomeTipoRecurso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

  if (instanciaData.id === 0) {
    instanciaData.tiporecurso = getParamFromUrl("tiporecurso");
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
        console.error("Erro ao submeter formulário de Instancia:", error);
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
          target: document.getElementById(`InstanciaForm-${instanciaData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Instancia diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Instancia' : 'form-container form-container-Instancia'}>
       
            <form className='formInputCadInc' id={`InstanciaForm-${instanciaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={instanciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`InstanciaForm-${instanciaData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nroprocesso"
            label="NroProcesso"
            className="inputIncNome"
            name="nroprocesso"
            value={instanciaData.nroprocesso}
            placeholder={`Informe NroProcesso`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="liminarpedida"
label="LiminarPedida"
className="inputIncNome"
name="liminarpedida"
value={instanciaData.liminarpedida}
onChange={onChange}               
/>

<InputInput
type="text"
id="objeto"
label="Objeto"
className="inputIncNome"
name="objeto"
value={instanciaData.objeto}
onChange={onChange}               
/>

<InputInput
type="text"
id="statusresultado"
label="StatusResultado"
className="inputIncNome"
name="statusresultado"
value={instanciaData.statusresultado}
onChange={onChange}               
/>

<InputCheckbox label="LiminarPendente" name="liminarpendente" checked={instanciaData.liminarpendente} onChange={onChange} />
<InputCheckbox label="InterpusemosRecurso" name="interpusemosrecurso" checked={instanciaData.interpusemosrecurso} onChange={onChange} />
<InputCheckbox label="LiminarConcedida" name="liminarconcedida" checked={instanciaData.liminarconcedida} onChange={onChange} />
<InputCheckbox label="LiminarNegada" name="liminarnegada" checked={instanciaData.liminarnegada} onChange={onChange} />
 
            <ProcessosComboBox
            name={'processo'}
            value={instanciaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={instanciaData.data}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="LiminarParcial" name="liminarparcial" checked={instanciaData.liminarparcial} onChange={onChange} />
        
<InputInput
type="text"
id="liminarresultado"
label="LiminarResultado"
className="inputIncNome"
name="liminarresultado"
value={instanciaData.liminarresultado}
onChange={onChange}               
/>

<InputInput
type="text"
id="divisao"
label="Divisao"
className="inputIncNome"
name="divisao"
value={instanciaData.divisao}
onChange={onChange}               
/>

<InputCheckbox label="LiminarCliente" name="liminarcliente" checked={instanciaData.liminarcliente} onChange={onChange} />
        
<InputInput
type="text"
id="comarca"
label="Comarca"
className="inputIncNome"
name="comarca"
value={instanciaData.comarca}
onChange={onChange}               
/>

<InputInput
type="text"
id="subdivisao"
label="SubDivisao"
className="inputIncNome"
name="subdivisao"
value={instanciaData.subdivisao}
onChange={onChange}               
/>

<InputCheckbox label="Principal" name="principal" checked={instanciaData.principal} onChange={onChange} />
 
            <AcaoComboBox
            name={'acao'}
            value={instanciaData.acao}
            setValue={addValorAcao}
            label={'Acao'}
            />

            <ForoComboBox
            name={'foro'}
            value={instanciaData.foro}
            setValue={addValorForo}
            label={'Foro'}
            />

            <TipoRecursoComboBox
            name={'tiporecurso'}
            value={instanciaData.tiporecurso}
            setValue={addValorTipoRecurso}
            label={'Tipo Recurso'}
            />

</div><div className="grid-container">        
<InputInput
type="text"
id="zkey"
label="ZKey"
className="inputIncNome"
name="zkey"
value={instanciaData.zkey}
onChange={onChange}               
/>

<InputInput
type="text"
id="zkeyquem"
label="ZKeyQuem"
className="inputIncNome"
name="zkeyquem"
value={instanciaData.zkeyquem}
onChange={onChange}               
/>

<InputInput
type="text"
id="zkeyquando"
label="ZKeyQuando"
className="inputIncNome"
name="zkeyquando"
value={instanciaData.zkeyquando}
onChange={onChange}               
/>

<InputInput
type="text"
id="nroantigo"
label="NroAntigo"
className="inputIncNome"
name="nroantigo"
value={instanciaData.nroantigo}
onChange={onChange}               
/>

<InputInput
type="text"
id="accesscode"
label="AccessCode"
className="inputIncNome"
name="accesscode"
value={instanciaData.accesscode}
onChange={onChange}               
/>

<InputInput
type="text"
id="julgador"
label="Julgador"
className="inputIncNome"
name="julgador"
value={instanciaData.julgador}
onChange={onChange}               
/>

<InputInput
type="text"
id="zkeyia"
label="ZKeyIA"
className="inputIncNome"
name="zkeyia"
value={instanciaData.zkeyia}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 