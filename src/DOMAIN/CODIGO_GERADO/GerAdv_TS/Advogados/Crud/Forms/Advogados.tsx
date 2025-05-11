// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IAdvogados } from '@/app/GerAdv_TS/Advogados/Interfaces/interface.Advogados';
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

import CargosComboBox from '@/app/GerAdv_TS/Cargos/ComboBox/Cargos';
import EscritoriosComboBox from '@/app/GerAdv_TS/Escritorios/ComboBox/Escritorios';
import { CargosApi } from '@/app/GerAdv_TS/Cargos/Apis/ApiCargos';
import { EscritoriosApi } from '@/app/GerAdv_TS/Escritorios/Apis/ApiEscritorios';
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
  }
  
  export const AdvogadosForm: React.FC<AdvogadosFormProps> = ({
    advogadosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeCargos, setNomeCargos] = useState('');
            const cargosApi = new CargosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeEscritorios, setNomeEscritorios] = useState('');
            const escritoriosApi = new EscritoriosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("cargos") > 0) {
  cargosApi
    .getById(getParamFromUrl("cargos"))
    .then((response) => {
      setNomeCargos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (advogadosData.id === 0) {
    advogadosData.cargo = getParamFromUrl("cargos");
  }
}
 
if (getParamFromUrl("escritorios") > 0) {
  escritoriosApi
    .getById(getParamFromUrl("escritorios"))
    .then((response) => {
      setNomeEscritorios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (advogadosData.id === 0) {
    advogadosData.escritorio = getParamFromUrl("escritorios");
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
        console.error("Erro ao submeter formulário de Advogados:", error);
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
          target: document.getElementById(`AdvogadosForm-${advogadosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Advogados diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Advogados' : 'form-container form-container-Advogados'}>
       
            <form className='formInputCadInc' id={`AdvogadosForm-${advogadosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={advogadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AdvogadosForm-${advogadosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={advogadosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

            <CargosComboBox
            name={'cargo'}
            value={advogadosData.cargo}
            setValue={addValorCargo}
            label={'Cargos'}
            />

<InputInput
type="email"
id="emailpro"
label="EMailPro"
className="inputIncNome"
name="emailpro"
value={advogadosData.emailpro}
onChange={onChange}               
/>

<InputCpf
type="text"
id="cpf"
label="CPF"
className="inputIncNome"
name="cpf"
value={advogadosData.cpf}
onChange={onChange}               
/>

<InputInput
type="text"
id="rg"
label="RG"
className="inputIncNome"
name="rg"
value={advogadosData.rg}
onChange={onChange}               
/>

<InputCheckbox label="Casa" name="casa" checked={advogadosData.casa} onChange={onChange} />
        
<InputInput
type="text"
id="nomemae"
label="NomeMae"
className="inputIncNome"
name="nomemae"
value={advogadosData.nomemae}
onChange={onChange}               
/>

            <EscritoriosComboBox
            name={'escritorio'}
            value={advogadosData.escritorio}
            setValue={addValorEscritorio}
            label={'Escritorios'}
            />

<InputCheckbox label="Estagiario" name="estagiario" checked={advogadosData.estagiario} onChange={onChange} />
        
<InputInput
type="text"
id="oab"
label="OAB"
className="inputIncNome"
name="oab"
value={advogadosData.oab}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="nomecompleto"
label="NomeCompleto"
className="inputIncNome"
name="nomecompleto"
value={advogadosData.nomecompleto}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={advogadosData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={advogadosData.cidade}
onChange={onChange}               
/>

<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={advogadosData.cep}
onChange={onChange}               
/>

<InputCheckbox label="Sexo" name="sexo" checked={advogadosData.sexo} onChange={onChange} />
        
<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={advogadosData.bairro}
onChange={onChange}               
/>

<InputInput
type="text"
id="ctpsserie"
label="CTPSSerie"
className="inputIncNome"
name="ctpsserie"
value={advogadosData.ctpsserie}
onChange={onChange}               
/>

<InputInput
type="text"
id="ctps"
label="CTPS"
className="inputIncNome"
name="ctps"
value={advogadosData.ctps}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={advogadosData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={advogadosData.fax}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="comissao"
label="Comissao"
className="inputIncNome"
name="comissao"
value={advogadosData.comissao}
onChange={onChange}               
/>

<InputInput
type="text"
id="dtinicio"
label="DtInicio"
className="inputIncNome"
name="dtinicio"
value={advogadosData.dtinicio}
onChange={onChange}               
/>

<InputInput
type="text"
id="dtfim"
label="DtFim"
className="inputIncNome"
name="dtfim"
value={advogadosData.dtfim}
onChange={onChange}               
/>

<InputInput
type="text"
id="dtnasc"
label="DtNasc"
className="inputIncNome"
name="dtnasc"
value={advogadosData.dtnasc}
onChange={onChange}               
/>

<InputInput
type="text"
id="salario"
label="Salario"
className="inputIncNome"
name="salario"
value={advogadosData.salario}
onChange={onChange}               
/>

<InputInput
type="text"
id="secretaria"
label="Secretaria"
className="inputIncNome"
name="secretaria"
value={advogadosData.secretaria}
onChange={onChange}               
/>

<InputInput
type="text"
id="textoprocuracao"
label="TextoProcuracao"
className="inputIncNome"
name="textoprocuracao"
value={advogadosData.textoprocuracao}
onChange={onChange}               
/>

<InputInput
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={advogadosData.email}
onChange={onChange}               
/>

<InputInput
type="text"
id="especializacao"
label="Especializacao"
className="inputIncNome"
name="especializacao"
value={advogadosData.especializacao}
onChange={onChange}               
/>

<InputInput
type="text"
id="pasta"
label="Pasta"
className="inputIncNome"
name="pasta"
value={advogadosData.pasta}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={advogadosData.observacao}
onChange={onChange}               
/>

<InputInput
type="text"
id="contabancaria"
label="ContaBancaria"
className="inputIncNome"
name="contabancaria"
value={advogadosData.contabancaria}
onChange={onChange}               
/>

<InputCheckbox label="ParcTop" name="parctop" checked={advogadosData.parctop} onChange={onChange} />
        
<InputInput
type="text"
id="class"
label="Class"
className="inputIncNome"
name="class"
value={advogadosData.class}
onChange={onChange}               
/>

<InputCheckbox label="Top" name="top" checked={advogadosData.top} onChange={onChange} />
<InputCheckbox label="Ani" name="ani" checked={advogadosData.ani} onChange={onChange} />

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 