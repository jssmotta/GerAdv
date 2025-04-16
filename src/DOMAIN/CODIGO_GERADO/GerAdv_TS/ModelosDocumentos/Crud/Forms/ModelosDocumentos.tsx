"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IModelosDocumentos } from '../../Interfaces/interface.ModelosDocumentos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import TipoModeloDocumentoComboBox from '@/app/GerAdv_TS/TipoModeloDocumento/ComboBox/TipoModeloDocumento';
import { TipoModeloDocumentoApi } from '@/app/GerAdv_TS/TipoModeloDocumento/Apis/ApiTipoModeloDocumento';

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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeTipoModeloDocumento && (<h2>{nomeTipoModeloDocumento}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={modelosdocumentosData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="remuneracao"
label="Remuneracao"
className="inputIncNome"
name="remuneracao"
value={modelosdocumentosData.remuneracao}
onChange={onChange}               
/>

<Input
type="text"
id="assinatura"
label="Assinatura"
className="inputIncNome"
name="assinatura"
value={modelosdocumentosData.assinatura}
onChange={onChange}               
/>

<Input
type="text"
id="header"
label="Header"
className="inputIncNome"
name="header"
value={modelosdocumentosData.header}
onChange={onChange}               
/>

<Input
type="text"
id="footer"
label="Footer"
className="inputIncNome"
name="footer"
value={modelosdocumentosData.footer}
onChange={onChange}               
/>

<Input
type="text"
id="extra1"
label="Extra1"
className="inputIncNome"
name="extra1"
value={modelosdocumentosData.extra1}
onChange={onChange}               
/>

<Input
type="text"
id="extra2"
label="Extra2"
className="inputIncNome"
name="extra2"
value={modelosdocumentosData.extra2}
onChange={onChange}               
/>

<Input
type="text"
id="extra3"
label="Extra3"
className="inputIncNome"
name="extra3"
value={modelosdocumentosData.extra3}
onChange={onChange}               
/>

<Input
type="text"
id="outorgante"
label="Outorgante"
className="inputIncNome"
name="outorgante"
value={modelosdocumentosData.outorgante}
onChange={onChange}               
/>

<Input
type="text"
id="outorgados"
label="Outorgados"
className="inputIncNome"
name="outorgados"
value={modelosdocumentosData.outorgados}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="poderes"
label="Poderes"
className="inputIncNome"
name="poderes"
value={modelosdocumentosData.poderes}
onChange={onChange}               
/>

<Input
type="text"
id="objeto"
label="Objeto"
className="inputIncNome"
name="objeto"
value={modelosdocumentosData.objeto}
onChange={onChange}               
/>

<Input
type="text"
id="titulo"
label="Titulo"
className="inputIncNome"
name="titulo"
value={modelosdocumentosData.titulo}
onChange={onChange}               
/>

<Input
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

<Input
type="text"
id="css"
label="CSS"
className="inputIncNome"
name="css"
value={modelosdocumentosData.css}
onChange={onChange}               
/>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 