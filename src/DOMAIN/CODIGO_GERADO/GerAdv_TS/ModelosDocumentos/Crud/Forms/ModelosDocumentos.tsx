// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IModelosDocumentos } from '@/app/GerAdv_TS/ModelosDocumentos/Interfaces/interface.ModelosDocumentos';
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

import TipoModeloDocumentoComboBox from '@/app/GerAdv_TS/TipoModeloDocumento/ComboBox/TipoModeloDocumento';
import { TipoModeloDocumentoApi } from '@/app/GerAdv_TS/TipoModeloDocumento/Apis/ApiTipoModeloDocumento';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'

interface ModelosDocumentosFormProps {
    modelosdocumentosData: IModelosDocumentos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ModelosDocumentosForm: React.FC<ModelosDocumentosFormProps> = ({
    modelosdocumentosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeTipoModeloDocumento, setNomeTipoModeloDocumento] = useState('');
            const tipomodelodocumentoApi = new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("tipomodelodocumento") > 0) {
  tipomodelodocumentoApi
    .getById(getParamFromUrl("tipomodelodocumento"))
    .then((response) => {
      setNomeTipoModeloDocumento(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (modelosdocumentosData.id === 0) {
    modelosdocumentosData.tipomodelodocumento = getParamFromUrl("tipomodelodocumento");
  }
}
 const addValorTipoModeloDocumento = (e: any) => {
                        if (e?.id>0)
                        modelosdocumentosData.tipomodelodocumento = e.id;
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
        console.error("Erro ao submeter formulário de ModelosDocumentos:", error);
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
          target: document.getElementById(`ModelosDocumentosForm-${modelosdocumentosData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar ModelosDocumentos diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-ModelosDocumentos' : 'form-container form-container-ModelosDocumentos'}>
       
            <form className='formInputCadInc' id={`ModelosDocumentosForm-${modelosdocumentosData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={modelosdocumentosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ModelosDocumentosForm-${modelosdocumentosData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

    <InputName
            type="text"            
            id="nome"
            label="Nome"
            className="inputIncNome"
            name="nome"
            value={modelosdocumentosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
          />

<InputInput
type="text"
id="remuneracao"
label="Remuneracao"
className="inputIncNome"
name="remuneracao"
value={modelosdocumentosData.remuneracao}
onChange={onChange}               
/>

<InputInput
type="text"
id="assinatura"
label="Assinatura"
className="inputIncNome"
name="assinatura"
value={modelosdocumentosData.assinatura}
onChange={onChange}               
/>

<InputInput
type="text"
id="header"
label="Header"
className="inputIncNome"
name="header"
value={modelosdocumentosData.header}
onChange={onChange}               
/>

<InputInput
type="text"
id="footer"
label="Footer"
className="inputIncNome"
name="footer"
value={modelosdocumentosData.footer}
onChange={onChange}               
/>

<InputInput
type="text"
id="extra1"
label="Extra1"
className="inputIncNome"
name="extra1"
value={modelosdocumentosData.extra1}
onChange={onChange}               
/>

<InputInput
type="text"
id="extra2"
label="Extra2"
className="inputIncNome"
name="extra2"
value={modelosdocumentosData.extra2}
onChange={onChange}               
/>

<InputInput
type="text"
id="extra3"
label="Extra3"
className="inputIncNome"
name="extra3"
value={modelosdocumentosData.extra3}
onChange={onChange}               
/>

<InputInput
type="text"
id="outorgante"
label="Outorgante"
className="inputIncNome"
name="outorgante"
value={modelosdocumentosData.outorgante}
onChange={onChange}               
/>

<InputInput
type="text"
id="outorgados"
label="Outorgados"
className="inputIncNome"
name="outorgados"
value={modelosdocumentosData.outorgados}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="poderes"
label="Poderes"
className="inputIncNome"
name="poderes"
value={modelosdocumentosData.poderes}
onChange={onChange}               
/>

<InputInput
type="text"
id="objeto"
label="Objeto"
className="inputIncNome"
name="objeto"
value={modelosdocumentosData.objeto}
onChange={onChange}               
/>

<InputInput
type="text"
id="titulo"
label="Titulo"
className="inputIncNome"
name="titulo"
value={modelosdocumentosData.titulo}
onChange={onChange}               
/>

<InputInput
type="text"
id="testemunhas"
label="Testemunhas"
className="inputIncNome"
name="testemunhas"
value={modelosdocumentosData.testemunhas}
onChange={onChange}               
/>

            <TipoModeloDocumentoComboBox
            name={'tipomodelodocumento'}
            value={modelosdocumentosData.tipomodelodocumento}
            setValue={addValorTipoModeloDocumento}
            label={'Tipo Modelo Documento'}
            />

<InputInput
type="text"
id="css"
label="CSS"
className="inputIncNome"
name="css"
value={modelosdocumentosData.css}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 