// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IContatoCRMOperador } from "../../Interfaces/interface.ContatoCRMOperador";
import { ContatoCRMOperadorService } from "../../Services/ContatoCRMOperador.service";
import { ContatoCRMOperadorApi } from "../../Apis/ApiContatoCRMOperador";
import ContatoCRMOperadorWindow from "./ContatoCRMOperadorWindow";

interface ContatoCRMOperadorWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ContatoCRMOperadorWindowId: React.FC<ContatoCRMOperadorWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const contatocrmoperadorService = useMemo(() => {
        return new ContatoCRMOperadorService(
            new ContatoCRMOperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IContatoCRMOperador | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await contatocrmoperadorService.fetchContatoCRMOperadorById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ContatoCRMOperadorWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedContatoCRMOperador={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ContatoCRMOperadorWindowId;