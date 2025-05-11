// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IEnquadramentoEmpresa } from "../../Interfaces/interface.EnquadramentoEmpresa";
import { EnquadramentoEmpresaService } from "../../Services/EnquadramentoEmpresa.service";
import { EnquadramentoEmpresaApi } from "../../Apis/ApiEnquadramentoEmpresa";
import EnquadramentoEmpresaWindow from "./EnquadramentoEmpresaWindow";

interface EnquadramentoEmpresaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const EnquadramentoEmpresaWindowId: React.FC<EnquadramentoEmpresaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const enquadramentoempresaService = useMemo(() => {
        return new EnquadramentoEmpresaService(
            new EnquadramentoEmpresaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IEnquadramentoEmpresa | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await enquadramentoempresaService.fetchEnquadramentoEmpresaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <EnquadramentoEmpresaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedEnquadramentoEmpresa={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default EnquadramentoEmpresaWindowId;