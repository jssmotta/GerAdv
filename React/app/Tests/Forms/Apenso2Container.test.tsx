import React from 'react';
import { render } from '@testing-library/react';
import Apenso2IncContainer from '@/app/GerAdv_TS/Apenso2/Components/Apenso2IncContainer';
// Apenso2IncContainer.test.tsx
// Mock do Apenso2Inc
jest.mock('@/app/GerAdv_TS/Apenso2/Crud/Inc/Apenso2', () => (props: any) => (
<div data-testid='apenso2-inc-mock' {...props} />
));
describe('Apenso2IncContainer', () => {
  it('deve renderizar Apenso2Inc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <Apenso2IncContainer id={id} navigator={mockNavigator} />
  );
  const apenso2Inc = getByTestId('apenso2-inc-mock');
  expect(apenso2Inc).toBeInTheDocument();
  expect(apenso2Inc.getAttribute('id')).toBe(id.toString());

});
});