// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IProValores } from "../../Interfaces/interface.ProValores";
import { ProValoresService } from "../../Services/ProValores.service";
import { ProValoresApi } from "../../Apis/ApiProValores";
import ProValoresWindow from "./ProValoresWindow";

interface ProValoresWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ProValoresWindowId: React.FC<ProValoresWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const provaloresService = useMemo(() => {
        return new ProValoresService(
            new ProValoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IProValores | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await provaloresService.fetchProValoresById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ProValoresWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedProValores={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ProValoresWindowId;