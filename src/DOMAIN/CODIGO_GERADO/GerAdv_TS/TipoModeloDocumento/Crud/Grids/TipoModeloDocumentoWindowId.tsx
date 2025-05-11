// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { ITipoModeloDocumento } from "../../Interfaces/interface.TipoModeloDocumento";
import { TipoModeloDocumentoService } from "../../Services/TipoModeloDocumento.service";
import { TipoModeloDocumentoApi } from "../../Apis/ApiTipoModeloDocumento";
import TipoModeloDocumentoWindow from "./TipoModeloDocumentoWindow";

interface TipoModeloDocumentoWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const TipoModeloDocumentoWindowId: React.FC<TipoModeloDocumentoWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const tipomodelodocumentoService = useMemo(() => {
        return new TipoModeloDocumentoService(
            new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<ITipoModeloDocumento | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await tipomodelodocumentoService.fetchTipoModeloDocumentoById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <TipoModeloDocumentoWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedTipoModeloDocumento={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default TipoModeloDocumentoWindowId;