// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IEnderecos } from "../../Interfaces/interface.Enderecos";
import { EnderecosService } from "../../Services/Enderecos.service";
import { EnderecosApi } from "../../Apis/ApiEnderecos";
import EnderecosWindow from "./EnderecosWindow";

interface EnderecosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const EnderecosWindowId: React.FC<EnderecosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const enderecosService = useMemo(() => {
        return new EnderecosService(
            new EnderecosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IEnderecos | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await enderecosService.fetchEnderecosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <EnderecosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedEnderecos={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default EnderecosWindowId;