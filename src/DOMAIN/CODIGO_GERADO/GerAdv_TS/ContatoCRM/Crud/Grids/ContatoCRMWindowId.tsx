// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IContatoCRM } from "../../Interfaces/interface.ContatoCRM";
import { ContatoCRMService } from "../../Services/ContatoCRM.service";
import { ContatoCRMApi } from "../../Apis/ApiContatoCRM";
import ContatoCRMWindow from "./ContatoCRMWindow";

interface ContatoCRMWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ContatoCRMWindowId: React.FC<ContatoCRMWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const contatocrmService = useMemo(() => {
        return new ContatoCRMService(
            new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IContatoCRM | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await contatocrmService.fetchContatoCRMById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ContatoCRMWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedContatoCRM={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ContatoCRMWindowId;