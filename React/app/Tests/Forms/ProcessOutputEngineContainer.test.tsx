import React from 'react';
import { render } from '@testing-library/react';
import ProcessOutputEngineIncContainer from '@/app/GerAdv_TS/ProcessOutputEngine/Components/ProcessOutputEngineIncContainer';
// ProcessOutputEngineIncContainer.test.tsx
// Mock do ProcessOutputEngineInc
jest.mock('@/app/GerAdv_TS/ProcessOutputEngine/Crud/Inc/ProcessOutputEngine', () => (props: any) => (
<div data-testid='processoutputengine-inc-mock' {...props} />
));
describe('ProcessOutputEngineIncContainer', () => {
  it('deve renderizar ProcessOutputEngineInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ProcessOutputEngineIncContainer id={id} navigator={mockNavigator} />
  );
  const processoutputengineInc = getByTestId('processoutputengine-inc-mock');
  expect(processoutputengineInc).toBeInTheDocument();
  expect(processoutputengineInc.getAttribute('id')).toBe(id.toString());

});
});