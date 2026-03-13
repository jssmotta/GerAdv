import React, { useState, useRef, useEffect } from 'react';
import { Button } from '@progress/kendo-react-buttons';
import { Input } from '@progress/kendo-react-inputs';
import { Card, CardBody } from '@progress/kendo-react-layout';
import { Loader } from '@progress/kendo-react-indicators';

const PixbolAIChatbot = () => {
  const [messages, setMessages] = useState([
    {
      id: 1,
      text: 'Olá! Sou sua assistente IA do PIXBOL. Posso responder perguntas sobre seus boletos, fornecedores, análises financeiras e relatórios. Como posso ajudá-lo hoje?',
      sender: 'bot',
      timestamp: new Date(),
    },
  ]);
  const [inputValue, setInputValue] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const [isOpen, setIsOpen] = useState(false);
  const messagesEndRef = useRef<HTMLDivElement | null>(null);

  const scrollToBottom = () => {
    messagesEndRef.current?.scrollIntoView({ behavior: 'smooth' });
  };

  useEffect(() => {
    scrollToBottom();
  }, [messages]);

  // Função para chamar sua API backend
  const sendToBackend = async (question: any) => {
    try {
      const response = await fetch('/api/ai-chat', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${localStorage.getItem('token')}`, // se usar auth
        },
        body: JSON.stringify({
          question: question,
          userId: 1, // pegar do contexto do usuário logado
        }),
      });

      if (!response.ok) {
        throw new Error('Erro na API');
      }

      const data = await response.json();

      // Se retornou uma tabela
      if (data.isTable && data.tableHtml) {
        return `${data.message}\n\n${data.tableHtml}`;
      }

      // Se retornou texto normal
      return data.answer || data.message;
    } catch (error) {
      console.error('Erro ao consultar IA:', error);
      return 'Desculpe, ocorreu um erro ao processar sua pergunta. Tente novamente em alguns instantes.';
    }
  };

  const handleSendMessage = async () => {
    if (!inputValue.trim() || isLoading) return;

    const userMessage = {
      id: Date.now(),
      text: inputValue,
      sender: 'user',
      timestamp: new Date(),
    };

    setMessages((prev) => [...prev, userMessage]);
    const currentQuestion = inputValue;
    setInputValue('');
    setIsLoading(true);

    try {
      // Chama seu backend que processará a pergunta e retornará a resposta
      const aiResponse = await sendToBackend(currentQuestion);

      const botMessage = {
        id: Date.now() + 1,
        text: aiResponse,
        sender: 'bot',
        timestamp: new Date(),
      };

      setMessages((prev) => [...prev, botMessage]);
    } catch (error) {
      const errorMessage = {
        id: Date.now() + 1,
        text: 'Desculpe, não consegui processar sua pergunta no momento. Tente novamente.',
        sender: 'bot',
        timestamp: new Date(),
      };
      setMessages((prev) => [...prev, errorMessage]);
    } finally {
      setIsLoading(false);
    }
  };

  const handleKeyPress = (e: any) => {
    if (e.key === 'Enter' && !e.shiftKey) {
      e.preventDefault();
      handleSendMessage();
    }
  };

  const clearChat = () => {
    setMessages([
      {
        id: 1,
        text: 'Chat limpo! Como posso ajudá-lo?',
        sender: 'bot',
        timestamp: new Date(),
      },
    ]);
  };

  const quickQuestions = [
    'Quantos boletos vencem esta semana?',
    'Qual meu maior gasto do mês?',
    'Mostre boletos em atraso',
    'Relatório de gastos por categoria',
    'Fluxo de caixa dos próximos 30 dias',
  ];

  const MessageBubble = ({
    message,
  }: {
    message: { text: string; sender: string; timestamp: Date };
  }) => {
    // Função para renderizar HTML que vem do backend
    const renderContent = (content: string) => {
      if (
        typeof content === 'string' &&
        (content.includes('<table') ||
          content.includes('<tr') ||
          content.includes('<td'))
      ) {
        return (
          <div
            className="html-content"
            dangerouslySetInnerHTML={{ __html: content }}
            style={{
              whiteSpace: 'pre-wrap',
              wordBreak: 'break-word',
            }}
          />
        );
      }
      // Senão, renderiza como texto normal
      return <div className="whitespace-pre-wrap break-words">{content}</div>;
    };

    return (
      <div
        className={`flex mb-4 ${message.sender === 'user' ? 'justify-end' : 'justify-start'}`}
      >
        <div
          className={`max-w-[85%] ${message.sender === 'user' ? 'order-2' : 'order-1'}`}
        >
          <div
            className={`px-4 py-3 rounded-2xl ${
              message.sender === 'user'
                ? 'bg-blue-600 text-white ml-12'
                : 'bg-gray-100 text-gray-800 mr-12'
            }`}
          >
            {renderContent(message.text)}
            <div
              className={`text-xs mt-2 ${
                message.sender === 'user' ? 'text-blue-200' : 'text-gray-500'
              }`}
            >
              {message.timestamp instanceof Date
                ? message.timestamp.toLocaleTimeString('pt-BR', {
                    hour: '2-digit',
                    minute: '2-digit',
                  })
                : ''}
            </div>
          </div>
        </div>
        <div
          className={`w-8 h-8 rounded-full flex items-center justify-center text-sm font-bold ${
            message.sender === 'user'
              ? 'bg-blue-600 text-white order-1 ml-3'
              : 'bg-orange-500 text-white order-2 mr-3'
          }`}
        >
          {message.sender === 'user' ? '👤' : '🤖'}
        </div>
      </div>
    );
  };

  return (
    <div className="fixed bottom-4 right-4 z-50">
      {/* Botão Flutuante */}
      {!isOpen && (
        <Button
          onClick={() => setIsOpen(true)}
          fillMode="solid"
          themeColor="primary"
          size="large"
          className="rounded-full w-16 h-16 shadow-lg hover:shadow-xl transition-shadow"
          title="Abrir Chat IA"
        >
          🤖
        </Button>
      )}

      {/* Janela do Chat */}
      {isOpen && (
        <Card className="w-96 h-[600px] shadow-2xl flex flex-col">
          {/* Header */}
          <CardBody className="p-0 flex flex-col h-full">
            <div className="bg-gradient-to-r from-blue-600 to-blue-700 text-white p-4 flex justify-between items-center">
              <div className="flex items-center">
                <span className="text-xl mr-2">🤖</span>
                <div>
                  <div className="font-semibold">IA PIXBOL</div>
                  <div className="text-xs text-blue-200">
                    Assistente Inteligente
                  </div>
                </div>
              </div>
              <div className="flex gap-2">
                <Button
                  onClick={clearChat}
                  fillMode="flat"
                  size="small"
                  className="text-white hover:bg-blue-500"
                  title="Limpar chat"
                >
                  🗑️
                </Button>
                <Button
                  onClick={() => setIsOpen(false)}
                  fillMode="flat"
                  size="small"
                  className="text-white hover:bg-blue-500"
                  title="Fechar"
                >
                  ✕
                </Button>
              </div>
            </div>

            {/* Messages Area */}
            <div className="flex-1 overflow-y-auto p-4 bg-white">
              {/* CSS para estilizar tabelas vindas do backend */}
              <style jsx>{`
                .html-content table {
                  width: 100%;
                  border-collapse: collapse;
                  margin: 8px 0;
                  font-size: 13px;
                  border: var(--table-border);
                  border-radius: 6px;
                  overflow: hidden;
                }

                .html-content th {
                  background-color: var(--table-bg);
                  padding: 8px 12px;
                  text-align: left;
                  font-weight: 600;
                  border-bottom: var(--table-border);
                  color: #374151;
                }

                .html-content td {
                  padding: 8px 12px;
                  border-bottom: 1px solid #f3f4f6;
                  color: #374151;
                }

                .html-content tr:hover {
                  background-color: var(--table-hover);
                }

                .html-content tr:last-child td {
                  border-bottom: none;
                }

                .html-content .money {
                  font-weight: 600;
                  color: #059669;
                }

                .html-content .money.negative {
                  color: #dc2626;
                }

                .html-content .center {
                  text-align: center;
                }

                .html-content .right {
                  text-align: right;
                }
              `}</style>

              {messages.map((message) => (
                <MessageBubble key={message.id} message={message} />
              ))}

              {isLoading && (
                <div className="flex justify-start mb-4">
                  <div className="bg-gray-100 rounded-2xl px-4 py-3 mr-12">
                    <Loader size="small" />
                    <span className="ml-2 text-gray-600">Pensando...</span>
                  </div>
                </div>
              )}

              <div ref={messagesEndRef} />
            </div>

            {/* Quick Questions */}
            {messages.length === 1 && (
              <div className="px-4 pb-2">
                <div className="text-xs text-gray-500 mb-2">
                  Perguntas rápidas:
                </div>
                <div className="flex flex-wrap gap-2">
                  {quickQuestions.map((question, index) => (
                    <Button
                      key={index}
                      onClick={() => setInputValue(question)}
                      size="small"
                      fillMode="outline"
                      className="text-xs"
                    >
                      {question}
                    </Button>
                  ))}
                </div>
              </div>
            )}

            {/* Input Area */}
            <div className="border-t p-4 bg-gray-50">
              <div className="flex gap-2">
                <Input
                  value={inputValue}
                  onChange={(e) => setInputValue(e.value)}
                  onKeyPress={handleKeyPress}
                  placeholder="Digite sua pergunta..."
                  className="flex-1"
                  disabled={isLoading}
                />
                <Button
                  onClick={handleSendMessage}
                  fillMode="solid"
                  themeColor="primary"
                  disabled={!inputValue.trim() || isLoading}
                  title="Enviar"
                >
                  ➤
                </Button>
              </div>
              <div className="text-xs text-gray-400 mt-2 text-center">
                Powered by IA PIXBOL • Dados em tempo real
              </div>
            </div>
          </CardBody>
        </Card>
      )}
    </div>
  );
};

export default PixbolAIChatbot;
