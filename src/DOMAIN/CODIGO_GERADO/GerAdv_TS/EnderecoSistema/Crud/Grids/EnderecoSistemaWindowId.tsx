// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IEnderecoSistema } from "../../Interfaces/interface.EnderecoSistema";
import { EnderecoSistemaService } from "../../Services/EnderecoSistema.service";
import { EnderecoSistemaApi } from "../../Apis/ApiEnderecoSistema";
import EnderecoSistemaWindow from "./EnderecoSistemaWindow";

interface EnderecoSistemaWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const EnderecoSistemaWindowId: React.FC<EnderecoSistemaWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const enderecosistemaService = useMemo(() => {
        return new EnderecoSistemaService(
            new EnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IEnderecoSistema | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await enderecosistemaService.fetchEnderecoSistemaById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <EnderecoSistemaWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedEnderecoSistema={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default EnderecoSistemaWindowId;