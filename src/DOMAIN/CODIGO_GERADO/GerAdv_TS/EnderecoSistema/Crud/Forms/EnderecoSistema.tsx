// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IEnderecoSistema } from '@/app/GerAdv_TS/EnderecoSistema/Interfaces/interface.EnderecoSistema';
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

import TipoEnderecoSistemaComboBox from '@/app/GerAdv_TS/TipoEnderecoSistema/ComboBox/TipoEnderecoSistema';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { TipoEnderecoSistemaApi } from '@/app/GerAdv_TS/TipoEnderecoSistema/Apis/ApiTipoEnderecoSistema';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCep from '@/app/components/Inputs/InputCep'

interface EnderecoSistemaFormProps {
    enderecosistemaData: IEnderecoSistema;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const EnderecoSistemaForm: React.FC<EnderecoSistemaFormProps> = ({
    enderecosistemaData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoEnderecoSistema, setNomeTipoEnderecoSistema] = useState('');
            const tipoenderecosistemaApi = new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipoenderecosistema") > 0) {
  tipoenderecosistemaApi
    .getById(getParamFromUrl("tipoenderecosistema"))
    .then((response) => {
      setNomeTipoEnderecoSistema(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (enderecosistemaData.id === 0) {
    enderecosistemaData.tipoenderecosistema = getParamFromUrl("tipoenderecosistema");
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

  if (enderecosistemaData.id === 0) {
    enderecosistemaData.processo = getParamFromUrl("processos");
  }
}
 const addValorTipoEnderecoSistema = (e: any) => {
                        if (e?.id>0)
                        enderecosistemaData.tipoenderecosistema = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        enderecosistemaData.processo = e.id;
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
        console.error("Erro ao submeter formulário de EnderecoSistema:", error);
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
          target: document.getElementById(`EnderecoSistemaForm-${enderecosistemaData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar EnderecoSistema diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-EnderecoSistema' : 'form-container form-container-EnderecoSistema'}>
       
            <form className='formInputCadInc' id={`EnderecoSistemaForm-${enderecosistemaData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={enderecosistemaData} isSubmitting={isSubmitting} onClose={onClose} formId={`EnderecoSistemaForm-${enderecosistemaData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

<InputInput
type="text"
id="cadastro"
label="Cadastro"
className="inputIncNome"
name="cadastro"
value={enderecosistemaData.cadastro}
onChange={onChange}               
/>

<InputInput
type="text"
id="cadastroexcod"
label="CadastroExCod"
className="inputIncNome"
name="cadastroexcod"
value={enderecosistemaData.cadastroexcod}
onChange={onChange}               
/>

            <TipoEnderecoSistemaComboBox
            name={'tipoenderecosistema'}
            value={enderecosistemaData.tipoenderecosistema}
            setValue={addValorTipoEnderecoSistema}
            label={'Tipo Endereco Sistema'}
            />

            <ProcessosComboBox
            name={'processo'}
            value={enderecosistemaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<InputInput
type="text"
id="motivo"
label="Motivo"
className="inputIncNome"
name="motivo"
value={enderecosistemaData.motivo}
onChange={onChange}               
/>

<InputInput
type="text"
id="contatonolocal"
label="ContatoNoLocal"
className="inputIncNome"
name="contatonolocal"
value={enderecosistemaData.contatonolocal}
onChange={onChange}               
/>

<InputInput
type="text"
id="cidade"
label="Cidade"
className="inputIncNome"
name="cidade"
value={enderecosistemaData.cidade}
onChange={onChange}               
/>

<InputInput
type="text"
id="endereco"
label="Endereco"
className="inputIncNome"
name="endereco"
value={enderecosistemaData.endereco}
onChange={onChange}               
/>

<InputInput
type="text"
id="bairro"
label="Bairro"
className="inputIncNome"
name="bairro"
value={enderecosistemaData.bairro}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputCep
type="text"
id="cep"
label="CEP"
className="inputIncNome"
name="cep"
value={enderecosistemaData.cep}
onChange={onChange}               
/>

<InputInput
type="text"
id="fone"
label="Fone"
className="inputIncNome"
name="fone"
value={enderecosistemaData.fone}
onChange={onChange}               
/>

<InputInput
type="text"
id="fax"
label="Fax"
className="inputIncNome"
name="fax"
value={enderecosistemaData.fax}
onChange={onChange}               
/>

<InputInput
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={enderecosistemaData.observacao}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 